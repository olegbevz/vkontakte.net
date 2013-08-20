// -----------------------------------------------------------------------
// <copyright file="Resource.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace vkontakte.net.Models
{
    using System.Xml.Serialization;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public abstract class Resource
    {
        public abstract int Id { get; set; }

        public abstract int OwnerId { get; set; }

        [XmlElement("url")]
        public virtual string Url { get; set; }

        public virtual string Extension { get; set; }

        public override string ToString()
        {
            return string.Format("{0}_{1}", OwnerId, Id);
        }
    }
}
