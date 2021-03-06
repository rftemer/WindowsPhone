﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NuBank.ViewModel
{
    public class Commands : ICommand
    {
        private Action<object> execute;

        private Predicate<object> canExecute;

        private event EventHandler CanExecuteChangedInternal;

       public Commands(Action<object> execute, Predicate<object> canExecute)
        {
            if (execute == null)
            {
                throw new ArgumentNullException("execute");
            }

            if (canExecute == null)
            {
                throw new ArgumentNullException("canExecute");
            }

            this.execute = execute;
            this.canExecute = canExecute;
        }

       public bool CanExecute(object parameter)
       {
           return this.canExecute != null && this.canExecute(parameter);
       }

       public void Execute(object parameter)
       {
           this.execute(parameter);
       }

       public event EventHandler CanExecuteChanged
       {
           add
           {
               //CommandManager.RequerySuggested += value;
               this.CanExecuteChangedInternal += value;
           }

           remove
           {
               //CommandManager.RequerySuggested -= value;
               this.CanExecuteChangedInternal -= value;
           }
       }
       public void OnCanExecuteChanged()
       {
           EventHandler handler = this.CanExecuteChangedInternal;
           if (handler != null)
           {
               //DispatcherHelper.BeginInvokeOnUIThread(() => handler.Invoke(this, EventArgs.Empty));
               handler.Invoke(this, EventArgs.Empty);
           }
       }

       public void Destroy()
       {
           this.canExecute = _ => false;
           this.execute = _ => { return; };
       }
    }
}
