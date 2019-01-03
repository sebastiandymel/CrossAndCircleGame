namespace CrossAndCircle.GameEngine
{
    public interface IPlayer
    {
        GameBoard.Player Id { get; }

        void RequestNextMove();
        void OnPlayerWon();
        void OnPlayerLose();
        void OnGameOver();
        void InitializeGameBoard(GameBoard board);
    }
}
