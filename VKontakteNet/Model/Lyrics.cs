// -----------------------------------------------------------------------
// <copyright file="Lyrics.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace VKontakteNet
{
    using System.Xml.Serialization;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class Lyrics
    {
        [XmlElement("lyrics_id")]
        public int Id { get; set; }

        [XmlElement("text")]
        public string Text { get; set; }
    }
}
