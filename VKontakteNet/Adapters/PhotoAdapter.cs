// -----------------------------------------------------------------------
// <copyright file="PhotoAdapter.cs" company="">
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
    public class PhotoAdapter : Adapter
    {
        public PhotoAdapter(Connection connection) : base(connection)
        {
        }

        public PhotoAlbum[] GetAlbums(int id)
        {
            var query = new NameValueCollection();

            query["uid"] = id.ToString();

            var document = ExecuteRequest("photos.getAlbums", query);

            var nodes = document.SelectNodes("response/album");

            return Helper.Deserialize<PhotoAlbum>(nodes);
        }

        public Photo[] GetPhotos(int userId, int albumId)
        {
            var query = new NameValueCollection();

            query["uid"] = userId.ToString();

            query["aid"] = albumId.ToString();

            var document = this.ExecuteRequest("photos.get", query);

            return Helper.Deserialize<Photo>(document.SelectNodes("response/photo"));
        }
    }
}
