namespace vkontakte.net.Adapters
{
    using vkontakte.net.Models;

    public interface IAudioAdapter
    {
        Audio[] GetUserAudio();

        /// <summary>
        /// Метод получает список аудиозаписей определенного пользователя
        /// </summary>
        /// <param name="id">Идентификатор пользователя</param>
        /// <returns>Список аудиозаписей</returns>
        Audio[] GetUserAudio(int id);

        Audio[] Search(AudioSearchOptions options);

        Lyrics GetLyrics(int id);

        int Add(Audio audio);
    }
}
