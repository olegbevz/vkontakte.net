// -----------------------------------------------------------------------
// <copyright file="UserCompact.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace vkontakte.net.Models
{
    using System.Xml.Serialization;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class UserCompact
    {
        [XmlElement("uid")]
        public int Id { get; set; }

        [XmlElement("first_name")]
        public string FirstName { get; set; }

        [XmlElement("last_name")]
        public string LastName { get; set; }

        [XmlElement("nickname")]
        public string NickName { get; set; }

        [XmlElement("sex")]
        public string Sex { get; set; }

        [XmlElement("online")]
        public bool Online { get; set; }
    }
}
