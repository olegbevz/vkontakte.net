namespace vkontakte.net.Adapters
{
    using System.Collections.Generic;

    using vkontakte.net.Models;

    public interface IAudioAdapter
    {
        /// <summary>
        /// Получение списка аудиозаписей текущего пользователя
        /// </summary>
        /// <returns>
        /// Список аудиозаписей
        /// </returns>
        IEnumerable<Audio> GetUserAudio();

        /// <summary>
        /// Метод получает список аудиозаписей определенного пользователя
        /// </summary>
        /// <param name="id">Идентификатор пользователя</param>
        /// <returns>Список аудиозаписей</returns>
        IEnumerable<Audio> GetUserAudio(int id);

        /// <summary>
        /// Поиск аудиозаписей
        /// </summary>
        /// <param name="options">
        /// Опции поиска аудиозаписей
        /// </param>
        /// <returns>
        /// Список аудиозаписей
        /// </returns>
        IEnumerable<Audio> Search(AudioSearchOptions options);

        /// <summary>
        /// Получение текста аудиозаписи
        /// </summary>
        /// <param name="id">
        /// Идентификатор аудиозаписи
        /// </param>
        /// <returns>
        /// The <see cref="Lyrics"/>.
        /// </returns>
        Lyrics GetLyrics(int id);

        /// <summary>
        /// Добавление аудиозаписи пользователю 
        /// </summary>
        /// <param name="audio">
        /// Аудиозапись
        /// </param>
        /// <returns>
        /// Идентификатор аудиозаписи
        /// </returns>
        int Add(Audio audio);
    }
}
