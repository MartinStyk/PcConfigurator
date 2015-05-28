﻿using System;
using System.Windows.Input;

namespace PcCOnfig.ViewModel
{
    public class DelegateCommand : ICommand
    {
        private readonly Action _action;

        public DelegateCommand(Action action)
        {
            _action = action;
        }

        public void Execute(object parameter)
        {
            _action();
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }
        //never used, but inherited from ICommand
        public event EventHandler CanExecuteChanged;
    }
}
