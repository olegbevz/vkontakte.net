// -----------------------------------------------------------------------
// <copyright file="Group.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace vkontakte.net.Models
{
    using System.Xml.Serialization;

    /// <summary>
    /// Модель группы
    /// </summary>
    public class Group
    {
        /// <summary>
        /// Gets or sets the id.
        /// идентификатор сообщества.
        /// </summary>
        [XmlElement("gid")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// Название сообщества.
        /// </summary>
        [XmlElement("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the screen name.
        /// Короткий адрес сообщества
        /// </summary>
        [XmlElement("screen_name")]
        public string ScreenName { get; set; }

        /// <summary>
        /// Gets or sets the is closed.
        /// Группа является закрытой
        /// </summary>
        [XmlElement("is_closed")]
        public string IsClosed { get; set; }

        /// <summary>
        /// Gets or sets the is admin.
        /// Является ли текущий пользователь руководителем сообществ
        /// </summary>
        [XmlElement("is_admin")]
        public string IsAdmin { get; set; }

        /// <summary>
        /// Gets or sets the photo.
        /// Url фотографии сообщества с размером 50x50px.
        /// </summary>
        [XmlElement("photo")]
        public string Photo { get; set; }

        /// <summary>
        /// Gets or sets the medium photo.
        /// Url фотографии сообщества с размером 100х100px.
        /// </summary>
        [XmlElement("photo_medium")]
        public string MediumPhoto { get; set; }

        /// <summary>
        /// Gets or sets the big photo.
        /// Url фотографии сообщества в максимальном размере.
        /// </summary>
        [XmlElement("photo_big")]
        public string BigPhoto { get; set; }
    }
}
