// -----------------------------------------------------------------------
// <copyright file="PhotoAlbum.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace vkontakte.net.Models
{
    using System.Xml.Serialization;

    /// <summary>
    /// Модель альбома с фотографиями
    /// </summary>
    public class PhotoAlbum
    {
        /// <summary>
        /// Gets or sets the id.
        /// Идентификатор альбома
        /// </summary>
        [XmlElement("aid")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the thumbid.
        /// </summary>
        [XmlElement("thumb_id")]
        public int ThumbId { get; set; }

        /// <summary>
        /// Gets or sets the owner id.
        /// Идентификатор владельца альбома
        /// </summary>
        [XmlElement("owner_id")]
        public int OwnerId { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// Заголовок альбома
        /// </summary>
        [XmlElement("title")]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// Описание альбома
        /// </summary>
        [XmlElement("description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the created.
        /// Дата создания альбома
        /// </summary>
        [XmlElement("created")]
        public string Created { get; set; }

        /// <summary>
        /// Gets or sets the updated.
        /// Дата последнего изменения альбома
        /// </summary>
        [XmlElement("updated")]
        public string Updated { get; set; }

        /// <summary>
        /// Gets or sets the size.
        /// Размер альбома
        /// </summary>
        [XmlElement("size")]
        public int Size { get; set; }

        /// <summary>
        /// Gets or sets the privacy.
        /// Уровень доступа к альбому
        /// </summary>
        [XmlElement("privacy")]
        public int Privacy { get; set; }
    }
}
