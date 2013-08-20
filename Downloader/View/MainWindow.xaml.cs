using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace VKDownloader
{
    using VKontakteNet;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            var connection = new Connection { ApplicationId = 34546546, Scope = (int)ScopeList.AccessToAudio };

            var dialog = new SigningWindow(connection);

            if (dialog.ShowDialog() != null)
            {
                Page.DataContext = new DownLoaderViewModel(dialog.Connection);
            }
            else
            {
                this.Close();
            }
        }
    }
}
