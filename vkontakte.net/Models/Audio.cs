// -----------------------------------------------------------------------
// <copyright file="Audio.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace vkontakte.net.Models
{
    using System.Xml.Serialization;

    /// <summary>
    /// Модель аудиозаписи
    /// </summary>
    public class Audio : Resource
    {
        /// <summary>
        /// Gets or sets the id.
        /// Идентификатор аудиозаписи
        /// </summary>
        [XmlElement("aid")]
        public override int Id { get; set; }

        /// <summary>
        /// Gets or sets the owner id.
        /// Идентификатор владельца
        /// </summary>
        [XmlElement("owner_id")]
        public override int OwnerId { get; set; }

        /// <summary>
        /// Gets or sets the artist.
        /// Исполнитель аудиозаписи
        /// </summary>
        [XmlElement("artist")]
        public string Artist { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// Заголовок аудиозаписи
        /// </summary>
        [XmlElement("title")]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the duration.
        /// Продолжительность аудиозаписи
        /// </summary>
        [XmlElement("duration")]
        public string Duration { get; set; }

        /// <summary>
        /// Gets or sets the lyrics id.
        /// Идентификатор тескта аудиозаписи
        /// </summary>
        [XmlElement("lyrics_id")]
        public int LyricsId { get; set; }

        /// <summary>
        /// The to string.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public override string ToString()
        {
            return "audio" + base.ToString();
        }
    }
}
