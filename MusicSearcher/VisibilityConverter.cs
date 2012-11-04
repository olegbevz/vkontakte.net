// --------------------------------------------------------------------------------------------------------------------
// <copyright file="VisibleOrHiddenConverter.cs" company="Русский САПР - Инновационные технологии">
//   Все права защищены (с) 2010-2011
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MusicSearcher
{
    using System;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Data;

    /// <summary>
    /// Конвертер для скрытия элемента в зависимости от поля типа bool
    /// </summary>
    public class VisibilityConverter : IValueConverter
    {
        #region Implemented Interfaces

        #region IValueConverter

        /// <summary>
        /// Преобразование bool к Visiblility
        /// </summary>
        /// <param name="value">
        /// Значение поля 
        /// </param>
        /// <param name="targetType">
        /// Исходный тип ?
        /// </param>
        /// <param name="parameter">
        /// Не используется
        /// </param>
        /// <param name="culture">
        /// Информация о культуре
        /// </param>
        /// <returns>
        /// Возвращает результат равенства параметра и значения поля
        /// </returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                return (bool)value ? Visibility.Visible : (Visibility)Enum.Parse(typeof(Visibility), parameter.ToString());
            }
            catch (Exception)
            {
                return DependencyProperty.UnsetValue;
            }
        }

        /// <summary>
        /// Преобразование Visibility к bool
        /// </summary>
        /// <param name="value">
        /// Значение поля
        /// </param>
        /// <param name="targetType">
        /// Исходный тип
        /// </param>
        /// <param name="parameter">
        /// Параметр указанный в radioButton
        /// </param>
        /// <param name="culture">
        /// Информация о культуре
        /// </param>
        /// <returns>
        /// Возвращает значение которое будет присвоено полю
        /// </returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                return (Visibility)value == Visibility.Visible ? true : false;
            }
            catch (Exception)
            {
                return DependencyProperty.UnsetValue;
            }
        }

        #endregion

        #endregion
    }
}