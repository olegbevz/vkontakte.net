// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Photo.cs" company="">
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
    /// Модель фотографии
    /// </summary>
    public class Photo : Resource
    {
        /// <summary>
        /// Gets or sets the id.
        /// идентификатор фотографии
        /// </summary>
        [XmlElement("pid")]
        public override int Id { get; set; }

        /// <summary>
        /// Gets or sets the almub id.
        /// идентификатор альбома, в котором находится фотография
        /// </summary>
        [XmlElement("aid")]
        public int AlmubId { get; set; }

        /// <summary>
        /// Gets or sets the owner id.
        /// идентификатор владельца фотографии
        /// </summary>
        [XmlElement("owner_id")]
        public override int OwnerId { get; set; }

        /// <summary>
        /// Gets or sets the source.
        /// url копии фотографии с максимальным размером 130x130px. 
        /// </summary>
        [XmlElement("src")]
        public string Source { get; set; }

        /// <summary>
        /// Gets or sets the source big.
        /// url копии фотографии с максимальным размером 604x604px. 
        /// </summary>
        [XmlElement("src_big")]
        public string SourceBig { get; set; }

        /// <summary>
        /// Gets or sets the source small.
        /// url копии фотографии с максимальным размером 75x75px. 
        /// </summary>
        [XmlElement("src_small")]
        public string SourceSmall { get; set; }

        /// <summary>
        /// Gets or sets the source x big.
        /// url копии фотографии с максимальным размером 807x807px. 
        /// </summary>
        [XmlElement("src_xbig")]
        public string SourceXBig { get; set; }

        /// <summary>
        /// Gets or sets the source xx big.
        /// url копии фотографии с максимальным размером 1280x1024px. 
        /// </summary>
        [XmlElement("src_xxbig")]
        public string SourceXxBig { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// текст описания фотографии. 
        /// </summary>
        [XmlElement("text")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the created.
        /// дата добавления в формате unixtime. 
        /// </summary>
        [XmlElement("created")]
        public string Created { get; set; }

        /// <summary>
        /// Gets or sets the url.
        /// </summary>
        public override string Url
        {
            get
            {
                return (((this.SourceXxBig ?? this.SourceXBig) ?? this.SourceBig) ?? this.Source) ?? this.SourceSmall;
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
