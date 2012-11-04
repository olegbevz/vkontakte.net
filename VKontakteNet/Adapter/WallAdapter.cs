// -----------------------------------------------------------------------
// <copyright file="WallAdapter.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace VKontakteNet
{
    using System.Collections.Specialized;
    using System.Linq;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class WallAdapter : Adapter
    {
        public WallAdapter(Connection connection) : base(connection)
        {

        }

        public void Post(int ownerId, string message, Resource[] attachments)
        {
            Post(ownerId, message, attachments.Select(media => media.ToString()).ToArray());
        }

        public Response Post(int ownerId, string message, string[] attachments)
        {
            var query = new NameValueCollection
                {
                    { "owner_id", ownerId.ToString() },
                    { "message", message },
                    { "attachments", attachments.WithComma() }
                };

            return new ValueResponse<int>(ExecuteRequest("wall.post", query));
        }
    }
}
