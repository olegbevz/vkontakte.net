// -----------------------------------------------------------------------
// <copyright file="Message.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace vkontakte.net.Models
{
    using System.Xml.Serialization;

    /// <summary>
    /// Сообщения
    /// </summary>
    public class Message
    {
        [XmlElement("mid")]
        public int Id { get; set; }
        
        [XmlElement("body")]
        public string Body { get; set; }

        [XmlElement("from_id")]
        public int SenderId { get; set; }

        [XmlElement("date")]
        public string Date { get; set; }

        [XmlElement("read_state")]
        public string ReadState { get; set; }
    }
}
