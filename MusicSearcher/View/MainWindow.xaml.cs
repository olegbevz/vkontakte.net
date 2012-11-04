using System.Windows;

namespace MusicSearcher
{
    using System;
    using System.Windows.Controls;

    using VKontakteNet;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow 
    {
        public MainWindow()
        {
            try
            {
                InitializeComponent();

                var connection = new Connection
                                     {
                                         ApplicationId = 2745992, 
                                         Scope = (int)ScopeList.AccessToAudio
                                     };


                //DataContext = new SearcherViewModel(new AudioAdapterLocal());

                var dialog = new SigningWindow(connection);

                if (dialog.ShowDialog() == true)
                {
                    DataContext = new SearcherViewModel(new AudioAdapter(dialog.Connection));
                }
                else
                {
                    Close();
                }

                //this.ListView.SizeChanged +=this.ListView_SizeChanged;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
