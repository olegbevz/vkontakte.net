using System;
using System.Windows.Media.Imaging;

namespace MusicSearcher
{
    public static class Resources
    {
        private static BitmapImage _addImage = GetResource("add.png");

        private static BitmapImage _playImape = GetResource("PlayHS.png");

        private static BitmapImage _pauseImage = GetResource("PauseHS.png");

        private static BitmapImage _stopImage = GetResource("StopHS.png");

        private static BitmapImage _saveImage = GetResource("saveHS.png");

        private static BitmapImage _openTextImage = GetResource("DocumentHS.png");

        private static BitmapImage _closeTextImage = GetResource("PageUpHS.png");

        private static BitmapImage _searchImage = GetResource("search.ico");

        private static BitmapImage _openSettingsImage = GetResource("327_Options_24x24_72.png");

        #region - Свойства -
        
        public static BitmapImage AddImage
        {
            get { return _addImage; }
        }

        public static BitmapImage PlayImape
        {
            get { return _playImape; }
        }

        public static BitmapImage PauseImage
        {
            get { return _pauseImage; }
        }

        public static BitmapImage StopImage
        {
            get { return _stopImage; }
        }

        public static BitmapImage SaveImage
        {
            get { return _saveImage; }
        }

        public static BitmapImage OpenTextImage
        {
            get { return _openTextImage; }
        }

        public static BitmapImage CloseTextImage
        {
            get { return _closeTextImage; }
        }

        public static BitmapImage SearchImage
        {
            get { return _searchImage; }
        }

        public static BitmapImage OpenSettingsImage
        {
            get { return _openSettingsImage; }
        }

        #endregion

        private static BitmapImage GetResource(string name)
        {
            return new BitmapImage(new Uri(string.Format("pack://application:,,,/MusicSearcher;component/Images/{0}", name)));
        }
    }
}
