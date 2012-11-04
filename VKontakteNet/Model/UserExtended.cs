// -----------------------------------------------------------------------
// <copyright file="UserProfile.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace VKontakteNet
{
    using System.Xml.Serialization;

    public class UserExtended : UserCompact
    {
        [XmlElement("domain")]
        public string Domain { get; set; }

        [XmlElement("bdate")]
        public string Birthday { get; set; }

        [XmlElement("city")]
        public int City { get; set; }

        [XmlElement("country")]
        public int Country { get; set; }

        [XmlElement("timezone")]
        public string TimeZone { get; set; }

        [XmlElement("photo")]
        public string PhotoUrl { get; set; }
        
        [XmlElement("has_mobile")]
        public bool HasMobule { get; set; }
        
        [XmlElement("rate")]
        public string Rate { get; set; }
        
        [XmlElement("contacts")]
        public string Contacts { get; set; }

        [XmlElement("can_post")]
        public bool CanPostOnWall { get; set; }

        [XmlElement("can_write_private_message")]
        public bool CanWritePrivateMessage { get; set; }

        [XmlElement("activity")]
        public string Status { get; set; }

        [XmlElement("relation")]
        public int Relation { get; set; }


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
