// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ViewModelBase.cs" company="Русский САПР - Инновационные технологии">
//   Все права защищены (с) 2010-2011
// </copyright>
// <summary>
//   Defines the NotifyPropertyChanged type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace vkontakte.net.ViewModels
{
    using System;
    using System.ComponentModel;

    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                VerifyPropertyName(this, propertyName);

                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public static void VerifyPropertyName(object viewModel, string propertyName)
        {
            // Verify that the property name matches a real,  
            // public, instance property on this object.
            if (TypeDescriptor.GetProperties(viewModel)[propertyName] == null)
            {
                throw new Exception("Invalid property name: " + propertyName);
            }
        }
    }
}
