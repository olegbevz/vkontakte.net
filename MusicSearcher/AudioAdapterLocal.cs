using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace VKontakteNet
{
    public class AudioAdapterLocal :IAudioAdapter
    {
        public Audio[] GetUserAudio()
        {
            return GetUserAudio(0);
        }

        public Audio[] GetUserAudio(int id)
        {
            return Search(null);
        }

        public Audio[] Search(AudioSearchOptions options)
        {
            var files = Directory.GetFiles(@"D:\Music\Music", "*.mp3");

            return files.Select(file => new Audio
                                            {
                                                Url = file,
                                                Artist = Path.GetFileNameWithoutExtension(file)
                                            }).ToArray();

        }

        public Lyrics GetLyrics(int id)
        {
            return new Lyrics {Text = "La La La La La La La La\nLa La La La La La La La\nLa La La La La La La La\n"};
        }

        public int Add(Audio audio)
        {
            throw new NotImplementedException();
        }
    }
}
