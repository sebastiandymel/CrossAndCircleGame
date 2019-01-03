namespace CrossAndCircle.GameEngine
{
    public static class GameBoardFactory
    {
        public static GameBoard Create(int size)
        {
            return new GameBoard(size, new WinningSchemas(size));
        }
    }
}
