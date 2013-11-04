// -----------------------------------------------------------------------
// <copyright file="PhotoAdapter.cs" company="">
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
    public class PhotoAdapter : Adapter
    {
        public PhotoAdapter(Connection connection) : base(connection)
        {
        }

        /// <summary>
        /// Получение списка альбомов с изображениями пользователя
        /// </summary>
        /// <param name="id">
        /// Идентификатор пользвателя
        /// </param>
        /// <returns>
        /// Список альбомов с изображениями
        /// </returns>
        public IEnumerable<PhotoAlbum> GetAlbums(int id)
        {
            var query = new NameValueCollection();

            query["uid"] = id.ToString();

            var document = ExecuteRequest("photos.getAlbums", query);

            var nodes = document.SelectNodes("response/album");

            return Extensions.Deserialize<PhotoAlbum>(nodes);
        }

        /// <summary>
        /// Получение списка изображений в альбоме
        /// </summary>
        /// <param name="userId">
        /// Идентификатор пользователя
        /// </param>
        /// <param name="albumId">
        /// Идентификатор альбома
        /// </param>
        /// <returns>
        /// Фоторгафии в альбоме
        /// </returns>
        public IEnumerable<Photo> GetPhotos(int userId, int albumId)
        {
            var query = new NameValueCollection();

            query["uid"] = userId.ToString();

            query["aid"] = albumId.ToString();

            var document = this.ExecuteRequest("photos.get", query);

            return Extensions.Deserialize<Photo>(document.SelectNodes("response/photo"));
        }
    }
}
