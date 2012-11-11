// -----------------------------------------------------------------------
// <copyright file="Lyrics.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace vkontakte.net.Models
{
    using System.Xml.Serialization;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class Lyrics
    {
        [XmlElement("lyrics_id")]
        public int Id { get; set; }

        [XmlElement("text")]
        public string Text { get; set; }
    }
}
