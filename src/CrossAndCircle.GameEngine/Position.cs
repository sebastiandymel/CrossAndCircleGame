namespace CrossAndCircle.GameEngine
{
    public class Position
    {
        public int X { get; set; }
        public int Y { get; set; }
        public GameBoard.Player? Player { get; set; }
        public bool IsEmpty() => Player == null;
    }
}
