namespace CrossAndCircle.GameEngine
{
    public class GameWonEventArgs
    {
        public GameBoard.Player Player { get;  }
        public int[] WinningIndexes { get; }
        public GameWonEventArgs(GameBoard.Player player, int[] winning)
        {
            Player = player;
            WinningIndexes = winning;
        }
    }
}
