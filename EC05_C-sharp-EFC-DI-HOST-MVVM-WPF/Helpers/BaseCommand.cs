﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EC05_C_sharp_EFC_DI_HOST_MVVM_WPF.Helpers
{
    internal abstract class BaseCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public virtual bool CanExecute(object? parameter) => true;

        public abstract void Execute(object? parameter);
    }
}
