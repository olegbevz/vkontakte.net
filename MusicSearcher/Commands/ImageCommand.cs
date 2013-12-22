namespace MusicSearcher
{
    using VKontakteNet;
    using System;
    using System.Windows;
    using System.Windows.Media.Imaging;
    using System.ComponentModel;
    using vkontakte.net.ViewModels;

    public class ImageCommand : RelayCommand
    {
        private BitmapImage _image;

        public ImageCommand(Action action, Predicate<object> execute, BitmapImage image)
            :base(action, execute)
        {
            _image = image;
        }

        public ImageCommand(Action action, BitmapImage image)
            : base(action)
        {
            _image = image;
        }

        public BitmapImage Image 
        { 
            get
            {
                return _image;
            }
            set
            {
                _image = value;

                OnPropertyChanged("Image");
            }
        }

        public override void Execute(object param)
        {
            try
            {
                _execute();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }   
    }
}
