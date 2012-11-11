// -----------------------------------------------------------------------
// <copyright file="PhotoAlbum.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace vkontakte.net.Models
{
    using System.Xml.Serialization;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class PhotoAlbum
    {
        [XmlElement("aid")]
        public int Id { get; set; }

        [XmlElement("thumb_id")]
        public int Thumbid { get; set; }

        [XmlElement("owner_id")]
        public int OwnerId { get; set; }

        [XmlElement("title")]
        public string Title { get; set; }

        [XmlElement("description")]
        public string Description { get; set; }

        [XmlElement("created")]
        public string Created { get; set; }

        [XmlElement("updated")]
        public string Updated { get; set; }

        [XmlElement("size")]
        public int Size { get; set; }

        [XmlElement("privacy")]
        public int Privacy { get; set; }
    }
}
