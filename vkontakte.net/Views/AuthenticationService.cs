using System.IO;
using System.Net;
using System.Reflection;
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
            var authenticationPage = RequestAuthenticationPage(connection);

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
    }
}