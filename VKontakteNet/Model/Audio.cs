// -----------------------------------------------------------------------
// <copyright file="Audio.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace VKontakteNet
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class Audio : Resource
    {
        [XmlElement("aid")]
        public override int Id { get; set; }

        [XmlElement("owner_id")]
        public override int OwnerId { get; set; }

        [XmlElement("artist")]
        public string Artist { get; set; }

        [XmlElement("title")]
        public string Title { get; set; }

        [XmlElement("duration")]
        public string Duration { get; set; }

        [XmlElement("lyrics_id")]
        public int LyricsId { get; set; }

        public override string FileName
        {
            get
            {
                return string.Format("{0}-{1}{2}", Artist, Title, Extension);
            }
        }

        public override string ToString()
        {
            return "audio" + base.ToString();
        }
    }
}
