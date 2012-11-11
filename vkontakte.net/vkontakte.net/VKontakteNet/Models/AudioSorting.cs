// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AudioSorting.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the AudioSorting type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace vkontakte.net.Models
{
    /// <summary>
    /// Способ сортировки аудиозаписей 
    /// </summary>
    public enum AudioSorting
    {
        /// <summary>
        /// Сортировка по популярности
        /// </summary>
        ByFamous = 2,

        /// <summary>
        /// Сортировка по продолжительности
        /// </summary>
        ByLength = 1,

        /// <summary>
        /// Сортировка по дате добавления
        /// </summary>
        ByAddingTime = 0
    }
}