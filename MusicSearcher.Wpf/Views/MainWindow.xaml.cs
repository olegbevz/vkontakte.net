// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MainWindow.xaml.cs" company="">
//   
// </copyright>
// <summary>
//   Interaction logic for MainWindow.xaml
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MusicSearcher.Wpf.Views
{
    using System;
    using System.Windows;

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
                this.InitializeComponent();

                var connection = new Connection
                                     {
                                         ApplicationId = 2745992, 
                                         Scope = (int)ScopeList.AccessToAudio
                                     };

                var dialog = new SigningWindow(connection);

                if (dialog.ShowDialog() == true)
                {
                    DataContext = new SearcherViewModel(new AudioAdapter(dialog.Connection));
                }
                else
                {
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
