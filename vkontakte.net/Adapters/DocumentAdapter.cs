// -----------------------------------------------------------------------
// <copyright file="DocumentAdapter.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace vkontakte.net.Adapters
{
    using System.Collections.Generic;
    using System.Collections.Specialized;

    using vkontakte.net.Models;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class DocumentAdapter : Adapter
    {
        public DocumentAdapter(Connection connection) : base(connection)
        {
        }

        /// <summary>
        /// Получение документов пользователя
        /// </summary>
        /// <param name="id">
        /// Идентификатор пользователя
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public IEnumerable<Document> GetDocuments(int id)
        {
            var query = new NameValueCollection();

            query["oid"] = id.ToString();

            var document = ExecuteRequest("docs.get", query);

            var nodes = document.SelectNodes("response/doc");

            return Extensions.Deserialize<Document>(nodes);
        }
    }
}
