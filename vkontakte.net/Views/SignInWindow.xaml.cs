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
            this.InitializeComponent();

            this.MinWidth = this.SignInControl.ClientSize.Width;

            this.MinHeight = this.SignInControl.ClientSize.Height;

            this.Connection = connection;

            this.SignInControl.SignInCompleted += OnSignInCompleted;

            this.SignInControl.Connect(this.Connection);
        }

        public void OnSignInCompleted(object sender, EventArgs e)
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
