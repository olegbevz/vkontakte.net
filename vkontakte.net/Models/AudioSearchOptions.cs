// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AudioSearchOptions.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the AudioSearchOptions type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace vkontakte.net.Models
{
    /// <summary>
    /// Модель настроек поиска аудиозаписи
    /// </summary>
    public class AudioSearchOptions
    {
        public AudioSearchOptions()
        {
            this.AutoComplete = true;

            this.Sorting = AudioSorting.ByFamous;

            this.Limit = 100;
        }

        /// <summary>
        /// Gets or sets the request.
        /// Строка запроса
        /// </summary>
        public string Request { get; set; }
        
        public bool AutoComplete { get; set; }

        public bool SearchLyrics { get; set; }

        /// <summary>
        /// Gets or sets the sorting.
        /// Сортировка возвращаемых аудиозаписей
        /// </summary>
        public AudioSorting Sorting { get; set; }

        public string SearchCount { get; set; }

        /// <summary>
        /// Gets or sets the limit.
        /// Максимальное количество возвращаемых аудиозаписей
        /// </summary>
        public int Limit { get; set; }
    }
}
