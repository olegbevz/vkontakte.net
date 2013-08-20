// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SignInWindow.xaml.cs" company="">
//   
// </copyright>
// <summary>
//   Interaction logic for SiningWindow.xaml
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace vkontakte.net.Views
{
    using System;
    using System.Windows;

    using vkontakte.net.Adapters;

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
                this.InitializeComponent();

                this.Width = this.SignInControl.ClientSize.Width;

                this.Height = this.SignInControl.ClientSize.Height;

                this.Connection = connection;

                this.SignInControl.AuthorizationCompleted += OnAuthorizationCompleted;

                this.SignInControl.StartAuthorization(this.Connection);
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
                this.DialogResult = this.SignInControl.Success;

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
