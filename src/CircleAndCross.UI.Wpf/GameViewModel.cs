using CrossAndCircle.GameEngine;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

namespace CircleAndCross.UI.Wpf
{
    public class GameViewModel : IGameStateObserver, INotifyPropertyChanged
    {
        #region Properties used by VIEW

        public ObservableCollection<PositionCommand> Items { get; set; } = new ObservableCollection<PositionCommand>();
        public ObservableCollection<GameMode> Modes { get; set; } = new ObservableCollection<GameMode>();
        public GameMode SelectedMode
        {
            get { return this.mode; }
            set
            {
                this.mode = value;
                RaisePropertyChanged(nameof(SelectedMode));
            }
        }
        public ICommand StartGameCommand { get; set; }
        public bool IsGameRunning
        {
            get { return this.isrunning; }
            set
            {
                this.isrunning = value;
                RaisePropertyChanged(nameof(IsGameRunning));
            }
        }
        #endregion Properties used by VIEW

        public GameViewModel()
        {
            StartGameCommand = new SimpleUiCommand(StartGame);
            Modes = new ObservableCollection<GameMode>
            {
                GameMode.Player_vs_Computer,
                GameMode.Player_vs_Player
            };
        }

        private void StartGame()
        {
            Items.Clear();
            this.p1 = new UserPlayer(GameBoard.Player.Circle);
            GenerateEmptyBoard();

            if (SelectedMode == GameMode.Player_vs_Computer)
            {
                this.game = GameFactory.CreateGameWithBot(p1, this);
            }
            else if (SelectedMode == GameMode.Player_vs_Player)
            {
                this.p2 = new UserPlayer(GameBoard.Player.Cross);
                this.game = GameFactory.Create1v1Game(p1, p2, this);
            }

            this.game.Start();
            IsGameRunning = true;
        }

        private void GenerateEmptyBoard()
        {
            var size = 3;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Items.Add(new PositionCommand(CurrentPlayer)
                    {
                        X = i,
                        Y = j
                    });
                }
            }
        }

        private Game game;
        private bool isrunning;
        private GameMode mode;
        private UserPlayer p1;
        private UserPlayer p2;
        private UserPlayer CurrentPlayer()
        {
            if (mode == GameMode.Player_vs_Computer)
            {
                return p1;
            }
            if (p1.CanMove)
            {
                return p1;
            }
            if (p2.CanMove)
            {
                return p2;
            }
            throw new InvalidOperationException();

        }

        #region IGameStateObserver members

        public void OnStateChanged(GameState newState)
        {
            newState.ForEach((x, y, p) =>
            {
                var item = Items.Single(i => i.X == x && i.Y == y);
                if (p == null)
                {
                    item.Occupation = PositionType.Empty;
                }
                else
                {
                    item.Occupation = p.Value == GameBoard.Player.Circle ? PositionType.Circle : PositionType.Cross;
                }
                item.Refresh();
            });
        }

        public void OnGameEnded(EndStatus status, Position[] winningPositions)
        {
            foreach (var item in winningPositions)
            {
                var boardItem = Items.Single(i => i.X == item.X && i.Y == item.Y);
                boardItem.WinningPosition = true;
            }
            IsGameRunning = false;
        }

        #endregion IGameStateObserver members

        #region INotifyPropertyChanged members

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        private void RaisePropertyChanged(string name)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        #endregion INotifyPropertyChanged members

    }
}
