// -----------------------------------------------------------------------
// <copyright file="Photo.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace vkontakte.net.Models
{
    using System.Xml.Serialization;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class Photo : Resource
    {
        [XmlElement("pid")]
        public override int Id { get; set; }

        [XmlElement("aid")]
        public int AlmubId { get; set; }

        [XmlElement("owner_id")]
        public override int OwnerId { get; set; }
        
        [XmlElement("src")]
        public string Source { get; set; }
        
        [XmlElement("src_big")]
        public string SourceBig { get; set; }

        [XmlElement("src_small")]
        public string SourceSmall { get; set; }

        [XmlElement("src_xbig")]
        public string SourceXBig { get; set; }

        [XmlElement("src_xxbig")]
        public string SourceXXBig { get; set; }

        [XmlElement("text")]
        public string Description { get; set; }

        [XmlElement("created")]
        public string Created { get; set; }

        public override string Url
        {
            get
            {
                return ((((this.SourceXXBig ?? this.SourceXBig) ?? this.SourceBig) ?? this.Source) ?? this.SourceSmall);
            }
            set
            {
                //throw NotImplementedException();
            }
        }

        public override string ToString()
        {
            return "photo" + base.ToString();
        }
    }
}
