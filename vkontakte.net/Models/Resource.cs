// -----------------------------------------------------------------------
// <copyright file="Resource.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace vkontakte.net.Models
{
    using System.Xml.Serialization;

    /// <summary>
    /// Модель файла (изображения, аудиозаписи или документа)
    /// </summary>
    public abstract class Resource
    {
        /// <summary>
        /// Gets or sets the id.
        /// Идентификатор ресурса
        /// </summary>
        public abstract int Id { get; set; }

        /// <summary>
        /// Gets or sets the owner id.
        /// Идентификатор владельца
        /// </summary>
        public abstract int OwnerId { get; set; }

        /// <summary>
        /// Gets or sets the url.
        /// Url для скачивания ресурса
        /// </summary>
        [XmlElement("url")]
        public virtual string Url { get; set; }

        /// <summary>
        /// Gets or sets the extension.
        /// Расширение файла
        /// </summary>
        public virtual string Extension { get; set; }

        /// <summary>
        /// The to string.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public override string ToString()
        {
            return string.Format("{0}_{1}", OwnerId, Id);
        }
    }
}
