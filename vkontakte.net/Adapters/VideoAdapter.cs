// -----------------------------------------------------------------------
// <copyright file="VideoAdapter.cs" company="">
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
    public class VideoAdapter : Adapter
    {
        public VideoAdapter(Connection connection) : base(connection)
        {

        }

        /// <summary>
        /// Получение списка видеозаписей пользователя
        /// </summary>
        /// <param name="id">
        /// Идентификатор пользователя
        /// </param>
        /// <returns>
        /// Список видеозписей пользователя
        /// </returns>
        public IEnumerable<Video> GetVideos(int id)
        {
            var query = new NameValueCollection();

            query["uid"] = id.ToString();

            var document = ExecuteRequest("video.get", query);

            var nodes = document.SelectNodes("response/video");

            return Extensions.Deserialize<Video>(nodes);
        }
    }
}
