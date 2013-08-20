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
    /// TODO: Update summary.
    /// </summary>
    public class Video
    {
        [XmlElement("vid")]
        public int Id { get; set; }

        [XmlElement("owner_id")]
        public int OwnerId { get; set; }

        [XmlElement("title")]
        public string Title  { get; set; }

        [XmlElement("description")]
        public string Description  { get; set; }

        [XmlElement("duration")]
        public string Duration  { get; set; }

        [XmlElement("link")]
        public string Link  { get; set; }

        [XmlElement("image")]
        public string Image  { get; set; }

        [XmlElement("date")]
        public string Date { get; set; }

        [XmlElement("player")]
        public string Player  { get; set; }

        [XmlElement("video")]
        public string VideoUrl { get; set; }
    }
}
