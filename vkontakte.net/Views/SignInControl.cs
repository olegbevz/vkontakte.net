// -----------------------------------------------------------------------
// <copyright file="AuthorisationControl.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace vkontakte.net.Views
{
    using System;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;

    using vkontakte.net.Adapters;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class SignInControl : WebBrowser
    {
        public bool Success;

        public Connection Connection { get; set; }

        public event EventHandler AuthorizationCompleted;

        public void StartAuthorization(Connection connection)
        {
            this.Connection = connection;

            const string uri = "http://api.vkontakte.ru/oauth/authorize?client_id={0}&scope={1}&display=popup&response_type=token";

            this.Navigate(new Uri(string.Format(uri, connection.ApplicationId, connection.Scope)));
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
                            this.Connection.AccessToken = m.Groups["value"].Value;
                            break;
                        case "user_id":
                            this.Connection.UserId = Convert.ToInt32(m.Groups["value"].Value);
                            break;
                    }
                }

                this.Success = true;

                if (string.IsNullOrEmpty(this.Connection.AccessToken))
                {
                    this.Success = false;
                }

                if (this.AuthorizationCompleted != null)
                {
                    this.AuthorizationCompleted.Invoke(this, new EventArgs());
                }
            }
            else if (e.Url.ToString().Contains("user_denied"))
            {
                this.Success = false;

                if (this.AuthorizationCompleted != null)
                {
                    this.AuthorizationCompleted.Invoke(this, new EventArgs());
                }
            }
        }
    }
}
