// -----------------------------------------------------------------------
// <copyright file="Connection.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace vkontakte.net.Adapters
{
    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class Connection
    {
        /// <summary>
        /// Gets or sets the user id.
        /// Идентификатор пользователя
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the application id.
        /// Идентификатор приложения
        /// </summary>
        public int ApplicationId { get; set; }

        /// <summary>
        /// Gets or sets the access token.
        /// Идентификатор подключения
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// Gets or sets the scope.
        /// Права доступа приложения
        /// </summary>
        public int Scope { get; set; }
    }
}
