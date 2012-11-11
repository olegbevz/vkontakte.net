// -----------------------------------------------------------------------
// <copyright file="WallAdapter.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace vkontakte.net
{
    using System.Collections.Specialized;
    using System.Linq;

    using VKontakteNet;

    using vkontakte.net.Models;

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
