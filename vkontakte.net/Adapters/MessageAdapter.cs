// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MessageAdapter.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the MessageAdapter type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace vkontakte.net.Adapters
{
    using System.Collections.Specialized;

    using vkontakte.net.Models;
    using vkontakte.net.Response;

    public class MessageAdapter : Adapter
    {
        /// <summary>
        /// Конструктор без параметров
        /// </summary>
        /// <param name="connection"></param>
        public MessageAdapter(Connection connection) : base(connection)
        {
            
        }

        /// <summary>
        /// Создать беседу с пользователями
        /// </summary>
        /// <param name="users">
        /// Идентификаторы пользователей
        /// </param>
        /// <param name="title">
        /// Заголовок беседы
        /// </param>
        /// <returns>
        /// Идентификатор беседы
        /// </returns>
        public int CreateChat(int[] users, string title)
        {
            var query = new NameValueCollection();

            query["uids"] = "id" + users.ToStringWithComma();

            var document = this.ExecuteRequest("messages.createChat", query);

            if (document.DocumentElement != null)
            {
                return int.Parse(document.DocumentElement.InnerText);
            }

            return 0;
        }

        /// <summary>
        /// Отправить сообщение
        /// </summary>
        /// <param name="recieverId">
        /// Идентификатор получателя
        /// </param>
        /// <param name="message">
        /// Текст сообщения
        /// </param>
        /// <param name="resources">
        /// Список прикрепленных данных
        /// </param>
        /// <returns>
        /// Результат запроса
        /// </returns>
        public ValueResponse<int> SendMessage(int recieverId, string message, Resource[] resources)
        {
            var query = new NameValueCollection
            {
                { "uid", recieverId.ToString() },
                { "chat_id", recieverId.ToString() },
                { "message", message }//,
                //{ "attachments", resources.WithComma() },
                //{ "title", "Заголовок сообщения" },
                //{ "type", "0" }
            };

            return new ValueResponse<int>(this.ExecuteRequest("messages.send", query));
        }

        /// <summary>
        /// Отправить сообщение пользователю
        /// </summary>
        /// <param name="recieverId">
        /// Идентификатор получателя
        /// </param>
        /// <param name="message">
        /// Текст сообщения
        /// </param>
        /// <returns>
        /// The <see cref="ValueResponse"/>.
        /// </returns>
        public ValueResponse<int> SendMessage(int recieverId, string message)
        {
            return SendMessage(recieverId, message, new Resource[] { });
        }

        /// <summary>
        /// Получение истории переписки
        /// </summary>
        /// <param name="chatterId">
        /// Идентификатор беседы
        /// </param>
        /// <returns>
        /// The <see cref="ArrayResponse"/>.
        /// </returns>
        public ArrayResponse<Message> GetHistory(int chatterId)
        {
            var query = new NameValueCollection
            {
                { "uid", chatterId.ToString() },
                { "count", "200" }
            };

            return new ArrayResponse<Message>(this.ExecuteRequest("messages.getHistory", query));
        }

        /// <summary>
        /// Пометить сообщение как непрочитанное
        /// </summary>
        /// <param name="messageIds">
        /// Список идентификаторов сообщений
        /// </param>
        public void MarkAsNew(int[] messageIds)
        {
            var query = new NameValueCollection
            {
                { "mids", messageIds.ToStringWithComma() }
            };

            var document = this.ExecuteRequest("messages.markAsNew", query);

            if (document.DocumentElement != null)
            {
                var result = int.Parse(document.DocumentElement.InnerText);
            }
        }

        /// <summary>
        /// Пометить сообщение как непрочтенное
        /// </summary>
        /// <param name="messageIds">
        /// Идентификатор сообщений
        /// </param>
        public void MarkAsRead(int[] messageIds)
        {
            var query = new NameValueCollection
            {
                { "mids", messageIds.ToStringWithComma() }
            };

            var document = this.ExecuteRequest("messages.markAsRead", query);

            if (document.DocumentElement != null)
            {
                var result = int.Parse(document.DocumentElement.InnerText);
            }
        }

        /// <summary>
        /// Удаление сообщения
        /// </summary>
        /// <param name="messageId">
        /// Идентификатор сообщения
        /// </param>
        /// <returns>
        /// The <see cref="ValueResponse"/>.
        /// </returns>
        public ValueResponse<bool> DeleteMessage(int messageId)
        {
            var query = new NameValueCollection
                {
                    { "mid", messageId.ToString() }
                };

            return new ValueResponse<bool>(this.ExecuteRequest("messages.delete", query));
        }
    }
}
