namespace VKontakteNet
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Collections.Specialized;

    public class MessageAdapter : Adapter
    {
        /// <summary>
        /// Конструктор без параметров
        /// </summary>
        /// <param name="connection"></param>
        public MessageAdapter(Connection connection) : base(connection)
        {
            
        }

        public int CreateChat(int[] users, string title)
        {
            var query = new NameValueCollection();

            query["uids"] = "id" + users.WithComma();

            var document = this.ExecuteRequest("messages.createChat", query);

            if (document.DocumentElement != null)
            {
                return int.Parse(document.DocumentElement.InnerText);
            }

            return 0;
        }

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

            return new ValueResponse<int>(ExecuteRequest("messages.send", query));
        }

        public ValueResponse<int> SendMessage(int recieverId, string message)
        {
            return SendMessage(recieverId, message, new Resource[] { });
        }

        public ArrayResponse<Message> GetHistory(int chatterId)
        {
            var query = new NameValueCollection
            {
                { "uid", chatterId.ToString() },
                { "count", "200" }
            };

            return new ArrayResponse<Message>(this.ExecuteRequest("messages.getHistory", query));
        }

        public void MarkAsNew(int[] messageIds)
        {
            var query = new NameValueCollection
            {
                { "mids", messageIds.WithComma() }
            };

            var document = this.ExecuteRequest("messages.markAsNew", query);

            if (document.DocumentElement != null)
            {
                var result = int.Parse(document.DocumentElement.InnerText);
            }
        }

        public void MarkAsRead(int[] messageIds)
        {
            var query = new NameValueCollection
            {
                { "mids", messageIds.WithComma() }
            };

            var document = this.ExecuteRequest("messages.markAsRead", query);

            if (document.DocumentElement != null)
            {
                var result = int.Parse(document.DocumentElement.InnerText);
            }
        }

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
