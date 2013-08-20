// -----------------------------------------------------------------------
// <copyright file="WallAdapter.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace vkontakte.net.Adapters
{
    using System.Collections.Specialized;
    using System.Linq;

    using vkontakte.net.Models;
    using vkontakte.net.Response;

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

            return new ValueResponse<int>(this.ExecuteRequest("wall.post", query));
        }
    }
}
