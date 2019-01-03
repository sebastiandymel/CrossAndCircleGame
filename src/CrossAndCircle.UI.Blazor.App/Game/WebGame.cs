using CrossAndCircle.GameEngine;
using System;

namespace CrossAndCircle.UI.Blazor.App
{
    public class WebGame : IGameStateObserver
    {
        private Game game;
        private WebPlayer p1;
        private WebPlayer p2;

        public void Start(GameBoard.Player id)
        {
            // CLEAR PREVIOUS STATE
            EndStatus = null;
            Current = null;
            WinningPositions = Array.Empty<Position>();

            // START NEW ONE
            p1 = new WebPlayer(id);
            p2 = null;
            game = GameFactory.CreateGameWithBot(p1, this);            
            game.Start();
        }

        public void Start(GameBoard.Player id1, GameBoard.Player id2)
        {
            // CLEAR PREVIOUS STATE
            EndStatus = null;
            Current = null;
            WinningPositions = Array.Empty<Position>();

            // START NEW ONE
            p1 = new WebPlayer(id1);
            p2 = new WebPlayer(id2);
            game = GameFactory.Create1v1Game(p1, p2, this);
            game.Start();
        }

        public void Move(int i, int j)
        {
            if (p1 != null && p2 != null)
            {
                if (p1.CanMove)
                {
                    this.p1.Move(i, j);
                }
                else if (this.p2.CanMove)
                {
                    this.p2.Move(i, j);
                }
            }
            else
            {
                p1.Move(i, j);
            }
        }

        public void OnStateChanged(GameState newState)
        {
            Current = newState;
            StateChanged(this, EventArgs.Empty);
        }

        public void OnGameEnded(EndStatus status, Position[] winningPositions)
        {
            WinningPositions = winningPositions;
            EndStatus = status;
            StateChanged(this, EventArgs.Empty);            
        }

        public GameState Current { get; private set; }
        public Position[] WinningPositions { get; private set; } = Array.Empty<Position>();
        public EndStatus? EndStatus { get; private set; }

        public event EventHandler StateChanged = delegate { };
    }
}
