// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Video.cs" company="">
//   TODO: Update copyright text.
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace vkontakte.net.Models
{
    using System.Xml.Serialization;

    /// <summary>
    /// Модель видеозаписи
    /// </summary>
    public class Video
    {
        /// <summary>
        /// Gets or sets the id.
        /// идентификатор видеозаписи.
        /// </summary>
        [XmlElement("vid")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the owner id.
        /// идентификатор владельца видеозаписи.
        /// </summary>
        [XmlElement("owner_id")]
        public int OwnerId { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// название видеозаписи.
        /// </summary>
        [XmlElement("title")]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// текст описания видеозаписи.
        /// </summary>
        [XmlElement("description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the duration.
        /// длительность ролика в секундах.
        /// </summary>
        [XmlElement("duration")]
        public string Duration { get; set; }

        /// <summary>
        /// Gets or sets the link.
        /// строка, состоящая из ключа video+vid.
        /// </summary>
        [XmlElement("link")]
        public string Link { get; set; }

        /// <summary>
        /// Gets or sets the image.
        /// </summary>
        [XmlElement("image")]
        public string Image { get; set; }

        /// <summary>
        /// Gets or sets the date.
        /// дата добавления видеозаписи в формате unixtime.
        /// </summary>
        [XmlElement("date")]
        public string Date { get; set; }

        /// <summary>
        /// Gets or sets the player.
        /// адрес страницы с плеером, который можно использовать для воспроизведения ролика в браузере.
        /// </summary>
        [XmlElement("player")]
        public string Player { get; set; }

        /// <summary>
        /// Gets or sets the video url.
        /// </summary>
        [XmlElement("video")]
        public string VideoUrl { get; set; }
    }
}
