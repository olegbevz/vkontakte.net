// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Lyrics.cs" company="">
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
    /// Текст произведения
    /// </summary>
    public class Lyrics
    {
        /// <summary>
        /// Gets or sets the id.
        /// Идентификатор текста песни
        /// </summary>
        [XmlElement("lyrics_id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the text.
        /// Текст песни
        /// </summary>
        [XmlElement("text")]
        public string Text { get; set; }
    }
}
