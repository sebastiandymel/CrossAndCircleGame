using System;
using System.ComponentModel;
using System.Windows.Input;

namespace CircleAndCross.UI.Wpf
{
    public class PositionCommand : ICommand, INotifyPropertyChanged
    {
        private PositionType _occupation;
        private bool _winningPosition;

        public PositionCommand(Func<UserPlayer> currentPlayer)
        {

            Player = currentPlayer;
        }

        public int X { get; set; }
        public int Y { get; set; }
        private Func<UserPlayer> Player { get; }

        public event EventHandler CanExecuteChanged = delegate { };
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public PositionType Occupation
        {
            get { return this._occupation; }
            set
            {
                this._occupation = value;
                RaisePropertyChanged(nameof(Occupation));
            }
        }

        public bool WinningPosition
        {
            get => _winningPosition;
            set
            {
                this._winningPosition = value;
                RaisePropertyChanged(nameof(WinningPosition));
            }
        }

        public bool CanExecute(object parameter)
        {
            return Player().CanMoveTo(X, Y);
        }
        public void Refresh()
        {
            CanExecuteChanged(this, EventArgs.Empty);
        }
        public void Execute(object parameter)
        {
            Player().DoMove(X, Y);
        }

        private void RaisePropertyChanged(string name)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}
