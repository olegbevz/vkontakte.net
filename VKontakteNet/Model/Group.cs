// -----------------------------------------------------------------------
// <copyright file="Group.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace VKontakteNet.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class Group
    {
        [XmlElement("gid")]
        public int Id { get; set; }

        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("screen_name")]
        public string ScreenName { get; set; }

        [XmlElement("is_closed")]
        public string IsClosed { get; set; }

        [XmlElement("is_admin")]
        public string IsAdmin { get; set; }

        [XmlElement("photo")]
        public string Photo { get; set; }

        [XmlElement("photo_medium")]
        public string MediumPhoto { get; set; }

        [XmlElement("photo_big")]
        public string BigPhoto { get; set; }
    }
}
