// -----------------------------------------------------------------------
// <copyright file="WallAdapter.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace vkontakte.net.Adapters
{
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Linq;

    using vkontakte.net.Models;
    using vkontakte.net.Response;

    public class WallAdapter : Adapter
    {
        public WallAdapter(Connection connection) : base(connection)
        {

        }

        /// <summary>
        /// Добавить сообщение на стену пользователю
        /// </summary>
        /// <param name="ownerId">
        /// Идентификатор пользователя
        /// </param>
        /// <param name="message">
        /// Текст сообщения
        /// </param>
        /// <param name="attachments">
        /// Прикрепленные к сообщению данные
        /// </param>
        public void Post(int ownerId, string message, IEnumerable<Resource> attachments)
        {
            Post(ownerId, message, attachments.Select(media => media.ToString()).ToArray());
        }

        /// <summary>
        /// Добавить сообщение на стену пользователю
        /// </summary>
        /// <param name="ownerId">
        /// Идентификатор пользователя
        /// </param>
        /// <param name="message">
        /// Текст сообщения
        /// </param>
        /// <param name="attachments">
        /// Прикрепленные к сообщению данные
        /// </param>
        /// <returns>
        /// The <see cref="Response"/>.
        /// </returns>
        public Response Post(int ownerId, string message, string[] attachments)
        {
            var query = new NameValueCollection
                {
                    { "owner_id", ownerId.ToString() },
                    { "message", message },
                    { "attachments", attachments.ToStringWithComma() }
                };

            return new ValueResponse<int>(this.ExecuteRequest("wall.post", query));
        }
    }
}
