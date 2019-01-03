using System;
using System.Windows.Input;

namespace CircleAndCross.UI.Wpf
{
    public class SimpleUiCommand : ICommand
    {
        private readonly Action a;

        public SimpleUiCommand(Action a)
        {
            this.a = a;
        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            a();
        }
    }
}
