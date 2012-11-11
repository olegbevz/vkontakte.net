// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Document.cs" company="">
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
    public class Document : Resource
    {
        [XmlElement("did")]
        public override int Id { get; set; }

        [XmlElement("owner_id")]
        public override int OwnerId { get; set; }

        [XmlElement("title")]
        public string Title  { get; set; }

        [XmlElement("size")]
        public string Size  { get; set; }

        [XmlElement("ext")]
        public override string Extension  { get; set; }

        public override string ToString()
        {
            return "doc" + base.ToString();
        }
    }
}
