// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RelayCommand.cs" company="Русский САПР - Инновационные технологии">
//   Все права защищены (с) 2010-2011
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace vkontakte.net.ViewModels
{
    using System;
    using System.Diagnostics;
    using System.Windows;
    using System.Windows.Input;

    /// <summary>
    /// Команда в паттерне ViewModel
    /// </summary>
    public class RelayCommand : ViewModelBase, ICommand
    {
        #region Fields

        /// <summary>
        /// Выполняемое действие
        /// </summary>
        protected readonly Action _execute;

        /// <summary>
        /// Признак возможности выполнения действия
        /// </summary>
        protected readonly Predicate<object> _canExecute;

        #endregion // Fields

        #region Constructors

        /// <summary>
        /// Конструктор 
        /// </summary>
        /// <param name="execute">Выполняемое действие</param>
        public RelayCommand(Action execute)
            : this(execute, null)
        {
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="execute"></param>
        /// <param name="canExecute"></param>
        public RelayCommand(Action execute, Predicate<object> canExecute):base()
        {
            if (execute == null)
                throw new ArgumentNullException("execute");

            this._execute = execute;
            this._canExecute = canExecute;
        }
        #endregion // Constructors

        #region ICommand Members

        /// <summary>
        /// Метод определяет есть ли возможность выполнить действие
        /// </summary>
        /// <param name="parameter">Входной параметр</param>
        /// <returns>Блокировка команды</returns>
        [DebuggerStepThrough]
        public virtual bool CanExecute(object parameter)
        {
            var canExecute = true;

            if (this._canExecute != null)
            {
                try
                {
                    canExecute = this._canExecute(parameter);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            return canExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        /// <summary>
        /// Метод выполняет действие
        /// </summary>
        /// <param name="parameter">Входной параметр</param>
        public virtual void Execute(object param)
        {
            try
            {
                this._execute();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion // ICommand Members
    }
}
