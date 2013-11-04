// -----------------------------------------------------------------------
// <copyright file="UserProfile.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace vkontakte.net.Models
{
    using System.Xml.Serialization;

    /// <summary>
    /// Расширенная модель пользователя
    /// </summary>
    public class UserExtended : UserCompact
    {
        [XmlElement("domain")]
        public string Domain { get; set; }

        /// <summary>
        /// Gets or sets the birthday.
        /// День рождения пользователя
        /// </summary>
        [XmlElement("bdate")]
        public string Birthday { get; set; }

        /// <summary>
        /// Gets or sets the city.
        /// Город пользователя
        /// </summary>
        [XmlElement("city")]
        public int City { get; set; }

        /// <summary>
        /// Gets or sets the country.
        /// Страна пользователя
        /// </summary>
        [XmlElement("country")]
        public int Country { get; set; }

        /// <summary>
        /// Gets or sets the time zone.
        /// Часовой пояс пользователя
        /// </summary>
        [XmlElement("timezone")]
        public string TimeZone { get; set; }

        /// <summary>
        /// Gets or sets the photo url.
        /// Url для скачивания фотографии пользователя
        /// </summary>
        [XmlElement("photo")]
        public string PhotoUrl { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether has mobule.
        /// Наличие фотографии пользователя
        /// </summary>
        [XmlElement("has_mobile")]
        public bool HasMobule { get; set; }

        /// <summary>
        /// Gets or sets the rate. 
        /// </summary>
        [XmlElement("rate")]
        public string Rate { get; set; }

        /// <summary>
        /// Gets or sets the contacts.
        /// информация о телефонных номерах пользователя
        /// </summary>
        [XmlElement("contacts")]
        public string Contacts { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether can post on wall.
        /// информация о том, разрешено ли оставлять записи на стене у пользователя
        /// </summary>
        [XmlElement("can_post")]
        public bool CanPostOnWall { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether can write private message.
        /// информация о том, разрешено ли написание личных сообщений данному пользователю.
        /// </summary>
        [XmlElement("can_write_private_message")]
        public bool CanWritePrivateMessage { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// статус пользователя.
        /// </summary>
        [XmlElement("activity")]
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the relation.
        /// семейное положение пользователя
        /// </summary>
        [XmlElement("relation")]
        public int Relation { get; set; }

        /// <summary>
        /// Gets or sets the education.
        /// информация о высшем учебном заведении пользователя. 
        /// </summary>
        [XmlElement("education")]
        public string Education { get; set; }
        
        //[XmlElement("university")]
        //public int University { get; set; }

        //[XmlElement("university_name")]
        //public string UniversityName { get; set; }

        //[XmlElement("faculity")]
        //public int Faculity { get; set; }

        //[XmlElement("faculity_name")]
        //public int FaculityName { get; set; }

        //[XmlElement("graduation")]
        //public int Graduation { get; set; }
    }
}
