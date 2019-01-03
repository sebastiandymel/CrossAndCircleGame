namespace CrossAndCircle.GameEngine
{
    public class PlayerMovedEventArgs
    {
        public GameBoard.Player Player { get; }
        public PlayerMovedEventArgs(GameBoard.Player player)
        {
            Player = player;
        }
    }
}
