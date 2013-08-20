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

        public int ApplicationId { get; set; }

        public string AccessToken { get; set; }

        public int Scope { get; set; }
    }
}
