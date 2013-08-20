// -----------------------------------------------------------------------
// <copyright file="VideoAdapter.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace vkontakte.net.Adapters
{
    using System.Collections.Specialized;

    using vkontakte.net.Models;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class VideoAdapter : Adapter
    {
        public VideoAdapter(Connection connection) : base(connection)
        {

        }

        public Video[] GetVideos(int id)
        {
            var query = new NameValueCollection();

            query["uid"] = id.ToString();

            var document = ExecuteRequest("video.get", query);

            var nodes = document.SelectNodes("response/video");

            return Helper.Deserialize<Video>(nodes);
        }
    }
}
