using System;
using System.Collections.Generic;

namespace MusicSearcher
{
    using VKontakteNet;

    public class AudioCollectionViewModel : List<AudioViewModel>
    {
        public AudioCollectionViewModel(Audio[] audios, Lyrics[] lyricses, IAudioAdapter adapter)
        {
            for (var i = 0; i < audios.Length; i++)
            {
                var audio = new AudioViewModel(audios[i], adapter, lyricses[i]);

                audio.StartPlayingHandler += this.OnStartPlaying;

                Add(audio);
            }
        }

        public AudioCollectionViewModel(Audio[] audios, IAudioAdapter adapter)
        {
            for (var i = 0; i < audios.Length; i++)
            {
                var audio = new AudioViewModel(audios[i], adapter);

                audio.StartPlayingHandler += this.OnStartPlaying;

                Add(audio);
            }
        }

        public void Stop()
        {
            foreach (var audio in this)
            {
                if (audio.IsPlaying)
                {
                    audio.StopCommand.Execute(null);
                }
            }
        }

        private void OnStartPlaying(object sender, EventArgs e)
        {
            foreach (var audio in this)
            {
                if (audio != sender && audio.IsPlaying)
                {
                    audio.PlayOrPauseCommand.Execute(null);
                }
            }
        }
    }
}
