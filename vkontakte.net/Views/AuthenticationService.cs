using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Xml;
using System.Xml.XPath;
using HtmlAgilityPack;
using vkontakte.net.Adapters;

namespace vkontakte.net.Views
{
    /// <summary>
    /// —ервис дл€ выполнени€ авторизации в фоновом режиме
    /// </summary>
    public class AuthenticationService
    {
        private const string AUTHORIZATION_URL = "https://oauth.vk.com/authorize";

        private const string API_VERSION = "4.0";

        private readonly Connection connection;

        public AuthenticationService(Connection connection)
        {
            this.connection = connection;
        }

        public bool Authenticate()
        {
            var authenticationPageStream = RequestAuthenticationPage(connection);
            var authenticationPageContent = StringFromStream(authenticationPageStream);
            var res = authenticationPageContent.Contains("access_token");

            var formInfo = GetHtmlFormInfo(authenticationPageContent);

            formInfo.Parameters["email"] = "olegdb@inbox.ru";
            formInfo.Parameters["pass"] = "olegdb@inbox.ru";

            var webRequest = CreateWebRequestFromFormInfo(formInfo);

            var responce = webRequest.GetResponse();

            var confirmPageContent = StringFromStream(responce.GetResponseStream());
            var res2 = confirmPageContent.Contains("access_token");
            var confirmPageForm = GetHtmlFormInfo(confirmPageContent);
            confirmPageForm.Parameters["email"] = "olegdb@inbox.ru";
            confirmPageForm.Parameters["pass"] = "olegdb@inbox.ru";


            var confirmPageRequest = CreateWebRequestFromFormInfo(confirmPageForm);

            var authenticationResponce = confirmPageRequest.GetResponse();
            var authenticationResponceContent = StringFromStream(authenticationResponce.GetResponseStream());
            var res3 = authenticationResponceContent.Contains("access_token");

            return false;
        }

        public bool Authenticate(string user, string password)
        {
            return false;
        }

        private Stream RequestAuthenticationPage(Connection connection)
        {
            string uri = string.Format("{0}?client_id={1}&scope={2}&redirect_uri={3}&display={4}&v={5}&response_type={6}",
                AUTHORIZATION_URL,
                connection.ApplicationId,
                connection.Scope,
                "https://oauth.vk.com/blank.html",
                "popup",
                API_VERSION,
                "token");

            var webRequest = WebRequest.Create(uri);

            var webResponce = webRequest.GetResponse();
            
            return webResponce.GetResponseStream();
        }

        private string StringFromStream(Stream stream)
        {
            using (var stringReader = new StreamReader(stream))
            {
                return stringReader.ReadToEnd();
            }
        }

        private HtmlFormInfo GetHtmlFormInfo(string htmlContent)
        {
            HtmlDocument document = new HtmlDocument();
            document.LoadHtml(htmlContent);
            HtmlNode formNode = document.DocumentNode.SelectSingleNode("//form");
            var method = formNode.GetAttributeValue("method", string.Empty);
            var action = formNode.GetAttributeValue("action", string.Empty);
            var htmlFormInfo = new HtmlFormInfo(method, action);
            
            HtmlNodeCollection inputNodes = formNode.SelectNodes("//input");

            foreach (var inputNode in inputNodes)
            {
                var name = inputNode.GetAttributeValue("name", string.Empty);
                var value = inputNode.GetAttributeValue("value", string.Empty);
                if (!string.IsNullOrEmpty(name))
                    htmlFormInfo.Parameters.Add(name, value);
            }

            return htmlFormInfo;
        }

        private WebRequest CreateWebRequestFromFormInfo(HtmlFormInfo formInfo)
        {
            string data = string.Join("&", formInfo.Parameters.Select(parameter => string.Format("{0}={1}", parameter.Key, parameter.Value))); //replace <value>
            byte[] dataStream = Encoding.UTF8.GetBytes(data);

            var webRequest = (HttpWebRequest)WebRequest.Create(formInfo.Action);
            webRequest.Method = formInfo.Method;
            webRequest.AllowAutoRedirect = false;
            webRequest.ContentType = "text/html; charset=utf-8";
            webRequest.ContentLength = dataStream.Length;
            using (var requestStream = webRequest.GetRequestStream())
            {
                requestStream.Write(dataStream, 0, dataStream.Length);
            }

            return webRequest;
        }

        private class HtmlFormInfo
        {
            public HtmlFormInfo(string method, string action)
            {
                Method = method;

                Action = action;

                Parameters = new Dictionary<string, string>();
            }

            public string Method { get; set; }

            public string Action { get; set; }

            public Dictionary<string, string> Parameters { get; private set; } 
        }
    }
}