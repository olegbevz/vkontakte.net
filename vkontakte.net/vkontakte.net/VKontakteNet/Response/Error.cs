namespace VKontakteNet
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