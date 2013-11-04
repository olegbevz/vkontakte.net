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

        /// <summary>
        /// Событие завершения авторизации
        /// </summary>
        public event EventHandler SignInCompleted;

        /// <summary>
        /// Gets or sets the connection.
        /// Настройки подключения
        /// </summary>
        public Connection Connection { get; set; }

        /// <summary>
        /// Подключение к базе данных вконтакте
        /// </summary>
        /// <param name="connection">
        /// The connection.
        /// </param>
        public void Connect(Connection connection)
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
                var regex = new Regex(@"(?<name>[\w\d\x5f]+)=(?<value>[^\x26\s]+)", RegexOptions.IgnoreCase | RegexOptions.Singleline);
                
                foreach (Match match in regex.Matches(e.Url.ToString()))
                {
                    switch (match.Groups["name"].Value)
                    {
                        case "access_token":
                            this.Connection.AccessToken = match.Groups["value"].Value;
                            break;
                        case "user_id":
                            this.Connection.UserId = Convert.ToInt32(match.Groups["value"].Value);
                            break;
                    }
                }

                this.Success = true;

                if (string.IsNullOrEmpty(this.Connection.AccessToken))
                {
                    this.Success = false;
                }

                if (this.SignInCompleted != null)
                {
                    this.SignInCompleted.Invoke(this, new EventArgs());
                }
            }
            else if (e.Url.ToString().Contains("user_denied"))
            {
                this.Success = false;

                if (this.SignInCompleted != null)
                {
                    this.SignInCompleted.Invoke(this, new EventArgs());
                }
            }
        }
    }
}
