// -----------------------------------------------------------------------
// <copyright file="AuthorisationControl.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace VKontakteNet
{
    using System;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class AuthorizationControl : WebBrowser
    {
        public bool Success;

        public Connection Connection { get; set; }

        public event EventHandler AuthorizationCompleted;

        public void StartAuthorization(Connection connection)
        {
            Connection = connection;

            const string uri = "http://api.vkontakte.ru/oauth/authorize?client_id={0}&scope={1}&display=popup&response_type=token";

            Navigate(new Uri(string.Format(uri, connection.ApplicationId, connection.Scope)));
        }

        protected override void OnDocumentCompleted(WebBrowserDocumentCompletedEventArgs e)
        {
            base.OnDocumentCompleted(e);

            if (e.Url.ToString().Contains("access_token"))
            {
                var myReg = new Regex(@"(?<name>[\w\d\x5f]+)=(?<value>[^\x26\s]+)", RegexOptions.IgnoreCase | RegexOptions.Singleline);
                
                foreach (Match m in myReg.Matches(e.Url.ToString()))
                {
                    switch (m.Groups["name"].Value)
                    {
                        case "access_token":
                            Connection.AccessToken = m.Groups["value"].Value;
                            break;
                        case "user_id":
                            Connection.UserId = Convert.ToInt32(m.Groups["value"].Value);
                            break;
                    }
                }

                Success = true;

                if (string.IsNullOrEmpty(Connection.AccessToken))
                {
                    Success = false;
                }

                if (AuthorizationCompleted != null)
                {
                    AuthorizationCompleted.Invoke(this, new EventArgs());
                }
            }
            else if (e.Url.ToString().Contains("user_denied"))
            {
                Success = false;

                if (AuthorizationCompleted != null)
                {
                    AuthorizationCompleted.Invoke(this, new EventArgs());
                }
            }
        }
    }
}
