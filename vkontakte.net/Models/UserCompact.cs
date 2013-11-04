// -----------------------------------------------------------------------
// <copyright file="UserCompact.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace vkontakte.net.Models
{
    using System.Xml.Serialization;

    /// <summary>
    /// Упрощенная модель пользователя
    /// </summary>
    public class UserCompact
    {
        /// <summary>
        /// Gets or sets the id.
        /// Идентификатор пользователя
        /// </summary>
        [XmlElement("uid")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// Имя пользователя
        /// </summary>
        [XmlElement("first_name")]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// Фамилия пользователя
        /// </summary>
        [XmlElement("last_name")]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the nick name.
        /// Ник пользователя
        /// </summary>
        [XmlElement("nickname")]
        public string NickName { get; set; }

        /// <summary>
        /// Gets or sets the sex.
        /// Пол пользователя
        /// </summary>
        [XmlElement("sex")]
        public string Sex { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether online.
        /// Признак наличия пользователя в сети
        /// </summary>
        [XmlElement("online")]
        public bool Online { get; set; }
    }
}
