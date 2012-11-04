using System.Windows.Controls;

namespace VKontakteNet
{
    using System;
    using System.Windows;

    /// <summary>
    /// Interaction logic for SiningWindow.xaml
    /// </summary>
    public partial class SigningWindow
    {
        public Connection Connection { get; set; }
        
        public SigningWindow(Connection connection)
        {
            try
            {
                InitializeComponent();

                this.Width = Page.AuthorizationControl.ClientSize.Width;

                this.Height = Page.AuthorizationControl.ClientSize.Height;

                Connection = connection;

                Page.AuthorizationControl.AuthorizationCompleted += OnAuthorizationCompleted;

                Page.AuthorizationControl.StartAuthorization(Connection);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void OnAuthorizationCompleted(object sender, EventArgs e)
        {
            try
            {
                DialogResult = Page.AuthorizationControl.Success;

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
