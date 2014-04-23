// -----------------------------------------------------------------------
// <copyright file="AudioViewModel.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

using System.Threading;

namespace MusicSearcher
{
    using System;
    using System.IO;
    using System.Net;
    using System.Windows.Controls;
    using System.Windows.Media.Imaging;

    using Microsoft.Win32;

    using VKontakteNet;
    using vkontakte.net.Adapters;
    using vkontakte.net.Models;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class AudioViewModel : ViewModelBase
    {
        private IAudioAdapter _adapter;

        private Audio _audio;

        private Lyrics _lyrics;

        private MediaElement _mediaElement;
        
        public AudioViewModel(Audio audio, IAudioAdapter adapter, Lyrics lyrics=null)
        {
            _audio = audio;

            _lyrics = lyrics;

            _adapter = adapter;

            _mediaElement = new MediaElement();

            PlayOrPauseImage = new DoubleImageViewModel(Resources.PlayImape, Resources.PauseImage);

            OpenOrCloseTextImage = new DoubleImageViewModel(Resources.OpenTextImage, Resources.CloseTextImage);
        }
        
        #region - Свойства -

        /// <summary>
        /// Gets the file name.
        /// </summary>
        public string FileName
        {
            get
            {
                return string.Format("{0}-{1}{2}", 
                    _audio.Artist, 
                    _audio.Title, 
                    Extension);
            }
        }

        public string Extension
        {
            get
            {
                return Path.GetExtension(_audio.Url);
            }
        }

        public string Text
        {
            get
            {
                return _lyrics == null ? string.Empty : _lyrics.Text;
            }
        }

        public bool HasText
        {
            get
            {
                return  _lyrics != null && Text != null;
            }
        }

        public bool IsPlaying
        {
            get { return PlayOrPauseImage.State; }
        }

        public DoubleImageViewModel OpenOrCloseTextImage { get; set; }

        public DoubleImageViewModel PlayOrPauseImage { get; set; }

        #endregion

        #region - Команды -

        public RelayCommand PlayOrPauseCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    if (PlayOrPauseImage.State)
                    {
                        _mediaElement.Pause();
                    }
                    else
                    {
                        if (_mediaElement.Source == null)
                        {
                            _mediaElement.LoadedBehavior = MediaState.Manual;

                            _mediaElement.UnloadedBehavior = MediaState.Manual;

                            _mediaElement.Source = new Uri(_audio.Url);
                        }

                        _mediaElement.Play();

                        _mediaElement.MediaEnded += (sender, e) => StopCommand.Execute(null);

                        if (StartPlayingHandler != null)
                        {
                            StartPlayingHandler.Invoke(this, new EventArgs());
                        }
                    }

                    PlayOrPauseImage.Change();
                });
            }
        }

        public ImageCommand StopCommand
        {
            get
            {
                return new ImageCommand(() =>
                {
                    _mediaElement.Stop();
                    PlayOrPauseImage.State = false;
                }, Resources.StopImage);
            }
        }

        public ImageCommand SaveCommand
        {
            get
            {
                return new ImageCommand(() =>
                {
                    var dialog = new SaveFileDialog
                        {
                            FileName = FileName, 
                            DefaultExt = Extension,
                            AddExtension = true,
                            Filter = string.Format("Music file|*{0}", Extension)
                        };

                    if (dialog.ShowDialog() == true)
                    {
                        new Thread(() =>
                        {
                            var webClient = new WebClient();

                            webClient.DownloadFile(_audio.Url, dialog.FileName);   

                        }).Start();
                    }
                },Resources.SaveImage);
            }
        }

        public ImageCommand AddCommand
        {
            get
            {
                return new ImageCommand(() => new Thread(() => _adapter.Add(_audio)).Start(), Resources.AddImage);
            }
        }

        public RelayCommand OpenOrCloseText
        {
            get
            {
                return new RelayCommand(() => OpenOrCloseTextImage.Change());
            }
        }
        
        #endregion

        public event EventHandler StartPlayingHandler;
    }
}
