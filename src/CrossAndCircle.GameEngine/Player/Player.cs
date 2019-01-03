namespace CrossAndCircle.GameEngine
{
    public class Player: IPlayer
    {
        protected GameBoard Board { get; private set; }
        private readonly GameBoard.Player playerId;

        public Player(GameBoard.Player playerId)
        {
            this.playerId = playerId;
        }

        public GameBoard.Player Id => this.playerId;

        public void InitializeGameBoard(GameBoard newBoard)
        {
            Board = newBoard;
            Board.PlayerMoved += OnMoved;
        }

        private void OnMoved(object sender, PlayerMovedEventArgs e)
        {
            if (e.Player == Id)
            {
                CanMove = false;
            }
        }

        public virtual void OnGameOver()
        {
            
        }

        public virtual void OnPlayerLose()
        {
            Loses++;
        }

        public virtual void OnPlayerWon()
        {
            Wins++;
        }

        public virtual void RequestNextMove()
        {
            CanMove = true;
        }

        public int Wins { get; private set; }
        public int Loses { get; private set; }
        public bool CanMove { get; private set; }
    }
}
