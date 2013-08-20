// -----------------------------------------------------------------------
// <copyright file="Audio.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace vkontakte.net.Models
{
    using System.Xml.Serialization;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class Audio : Resource
    {
        [XmlElement("aid")]
        public override int Id { get; set; }

        [XmlElement("owner_id")]
        public override int OwnerId { get; set; }

        [XmlElement("artist")]
        public string Artist { get; set; }

        [XmlElement("title")]
        public string Title { get; set; }

        [XmlElement("duration")]
        public string Duration { get; set; }

        [XmlElement("lyrics_id")]
        public int LyricsId { get; set; }

        public override string ToString()
        {
            return "audio" + base.ToString();
        }
    }
}
