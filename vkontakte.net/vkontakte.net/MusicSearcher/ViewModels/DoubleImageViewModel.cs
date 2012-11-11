using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;
using VKontakteNet;

namespace MusicSearcher
{
    public class DoubleImageViewModel : ViewModelBase
    {
        private BitmapImage _firstImage;

        private BitmapImage _secondImage;

        private bool _state;

        public DoubleImageViewModel(BitmapImage firstImage, BitmapImage secondImage)
        {
            _firstImage = firstImage;

            _secondImage = secondImage;
        }

        public void Change()
        {
            State = !State;
        }

        public bool State
        {
            get
            {
                return _state;
            }

            set 
            { 
                _state = value;

                OnPropertyChanged("State");

                OnPropertyChanged("Image");
            }
        }

        public BitmapImage Image
        {
            get { return _state ? _secondImage : _firstImage; }
        }
    }
}
