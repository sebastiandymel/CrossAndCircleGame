namespace CrossAndCircle.GameEngine
{
    internal static class PlayerExtensions
    {
        internal static GameBoard.Player Other(this GameBoard.Player pl)
        {
            if (pl == GameBoard.Player.Circle)
            {
                return GameBoard.Player.Cross;
            }
            return GameBoard.Player.Circle;
        }
    }
}
