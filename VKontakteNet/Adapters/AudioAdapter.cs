// -----------------------------------------------------------------------
// <copyright file="AudioAdapter.cs" company="">
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
    public class AudioAdapter : Adapter, IAudioAdapter
    {
        public AudioAdapter(Connection connection) : base(connection)
        {
        }

        public Audio[] GetUserAudio()
        {
            return GetUserAudio(_connection.UserId);
        }

        /// <summary>
        /// Метод получает список аудиозаписей определенного пользователя
        /// </summary>
        /// <param name="id">Идентификатор пользователя</param>
        /// <returns>Список аудиозаписей</returns>
        public Audio[] GetUserAudio(int id)
        {
            var query = new NameValueCollection { {"uid", id.ToString() } };

            var document = ExecuteRequest("audio.get", query);

            var nodes = document.SelectNodes("response/audio");

            return nodes.Deserialize<Audio>();
        }

        public Audio[] Search(AudioSearchOptions options)
        {
            var query = new NameValueCollection
            {
                { "q", options.Request },
                { "auto_complete", (options.AutoComplete ? 1 : 0).ToString()},
                { "sort", ((int)options.Sorting).ToString()},
                { "lyrics", (options.SearchLyrics? 1 : 0).ToString()},
                { "count", options.Limit.ToString()}
            };

            var document = ExecuteRequest("audio.search", query);

            var nodes = document.SelectNodes("response/audio");

            return nodes.Deserialize<Audio>();
        }

        public Lyrics GetLyrics(int id)
        {
            var query = new NameValueCollection{ {"lyrics_id", id.ToString()} };

            var document = ExecuteRequest("audio.getLyrics", query);

            return document.SelectSingleNode("response/lyrics").Deserialize<Lyrics>();
        }

        public int Add(Audio audio)
        {
            var query = new NameValueCollection
                {
                    {"api_id", _connection.ApplicationId.ToString()},
                    {"sig", _connection.AccessToken},
                    {"aid", audio.Id.ToString()},
                    {"oid", audio.OwnerId.ToString()}
                };

            var document = ExecuteRequest("audio.add", query);

            var audioId = -1;

            if (document.DocumentElement != null)
            {
                int.TryParse(document.DocumentElement.Value, out audioId);
            }

            return audioId;
        }
    }
}
