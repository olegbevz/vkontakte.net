// -----------------------------------------------------------------------
// <copyright file="VideoAdapter.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace VKontakteNet
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Linq;
    using System.Text;

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
