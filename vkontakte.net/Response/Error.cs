// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Error.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the Error type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace vkontakte.net.Response
{
    using System.Xml.Serialization;

    [XmlRoot("error")]
    public class Error
    {
        [XmlElement("error_code")]
        public int Code { get; set; }

        [XmlElement("error_msg")]
        public string Message { get; set; }
    }
}