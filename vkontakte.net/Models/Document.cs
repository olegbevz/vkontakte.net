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
    /// Модель документа
    /// </summary>
    public class Document : Resource
    {
        /// <summary>
        /// Gets or sets the id.
        /// Идентификатор документа
        /// </summary>
        [XmlElement("did")]
        public override int Id { get; set; }

        /// <summary>
        /// Gets or sets the owner id.
        /// Идентификатор владельца документа
        /// </summary>
        [XmlElement("owner_id")]
        public override int OwnerId { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// Заголовок документа
        /// </summary>
        [XmlElement("title")]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the size.
        /// Размер документа
        /// </summary>
        [XmlElement("size")]
        public string Size { get; set; }

        /// <summary>
        /// Gets or sets the extension.
        /// Расширение документа
        /// </summary>
        [XmlElement("ext")]
        public override string Extension { get; set; }

        /// <summary>
        /// The to string.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public override string ToString()
        {
            return "doc" + base.ToString();
        }
    }
}
