using System;
using System.Collections.Generic;

namespace CrossAndCircle.GameEngine
{
    public class Game
    {
        private readonly GameBoard board;
        private readonly IPlayer p1;
        private readonly IPlayer p2;
        private readonly IGameStateObserver gameObserver;
        private readonly StateVisitor stateVisitor = new StateVisitor();

        public Game(
            GameBoard board, 
            IPlayer p1, 
            IPlayer p2, 
            IGameStateObserver gameObserver)
        {
            this.board = board;
            this.p1 = p1;
            this.p2 = p2;
            this.gameObserver = gameObserver;
            this.board.GameWon += OnGameWon;
            this.board.GameTied += OnGameTied;
            this.board.PlayerMoved += OnPlayerMoved;
        }

        public void Start()
        {
            this.board.ClearGame();
            this.p1.InitializeGameBoard(this.board);
            this.p2.InitializeGameBoard(this.board);

            RaiseStateChanged();

            this.p1.RequestNextMove();
        }

        public void EndGame()
        {
            board.ClearGame();
            RaiseStateChanged();
        }

        private void OnGameWon(object sender, GameWonEventArgs e)
        {
            this[e.Player].OnPlayerWon();
            this[e.Player.Other()].OnPlayerLose();
            RaiseStateChanged();
            var status = e.Player == GameBoard.Player.Circle ? EndStatus.CircleWins : EndStatus.CrossWins;
            var winners = new List<Position>();
            foreach (var item in e.WinningIndexes)
            {
                winners.Add(new Position
                {
                    X = item % board.BoardSize,
                    Y = item / board.BoardSize,
                    Player = e.Player
                });
            }
            this.gameObserver.OnGameEnded(status, winners.ToArray());
        }

        private void OnPlayerMoved(object sender, PlayerMovedEventArgs e)
        {
            RaiseStateChanged();
            var nextPlayer = e.Player.Other();
            if (!board.IsGameOver)
            {
                this[nextPlayer].RequestNextMove();
            }
        }

        private void OnGameTied(object sender, EventArgs e)
        {
            this.gameObserver.OnGameEnded(EndStatus.Draw, Array.Empty<Position>());
        }

        private void RaiseStateChanged()
        {
            this.gameObserver.OnStateChanged(
                new GameState(
                    GetStateFromBoard(this.board)));
        }

        private IEnumerable<Position> GetStateFromBoard(GameBoard board)
        {
            this.board.Accept(this.stateVisitor);
            return this.stateVisitor.Current;
        }

        private IPlayer this[GameBoard.Player player]
        {
            get
            {
                if (p1.Id == player)
                {
                    return p1;
                }
                if (p2.Id == player)
                {
                    return p2;
                }
                throw new InvalidOperationException($"There is no player with Id {player}");
            }
        }
    }
}
