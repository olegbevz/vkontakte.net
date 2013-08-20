// -----------------------------------------------------------------------
// <copyright file="Message.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace vkontakte.net.Models
{
    using System.Xml.Serialization;

    /// <summary>
    /// Модель сообщения
    /// </summary>
    public class Message
    {
        /// <summary>
        /// Gets or sets the id.
        /// Идентификатор сообщения
        /// </summary>
        [XmlElement("mid")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the body.
        /// Текст сообщения
        /// </summary>
        [XmlElement("body")]
        public string Body { get; set; }

        /// <summary>
        /// Gets or sets the sender id.
        /// Идентификатор отправления
        /// </summary>
        [XmlElement("from_id")]
        public int SenderId { get; set; }

        /// <summary>
        /// Gets or sets the date.
        /// Дата отправки сообщения в формате unixtime
        /// </summary>
        [XmlElement("date")]
        public string Date { get; set; }

        /// <summary>
        /// Gets or sets the read state.
        /// Cтатус сообщения
        /// </summary>
        [XmlElement("read_state")]
        public string ReadState { get; set; }
    }
}
