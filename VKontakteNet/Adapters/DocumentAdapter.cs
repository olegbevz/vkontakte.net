// -----------------------------------------------------------------------
// <copyright file="DocumentAdapter.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace VKontakteNet
{
    using System.Collections.Specialized;

    using vkontakte.net;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class DocumentAdapter : Adapter
    {
        public DocumentAdapter(Connection connection) : base(connection)
        {
        }

        public Document[] GetDocuments(int id)
        {
            var query = new NameValueCollection();

            query["oid"] = id.ToString();

            var document = ExecuteRequest("docs.get", query);

            var nodes = document.SelectNodes("response/doc");

            return Helper.Deserialize<Document>(nodes);
        }
    }
}
