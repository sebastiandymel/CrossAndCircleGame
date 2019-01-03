using System.Collections.Generic;

namespace CrossAndCircle.GameEngine
{
    internal class StateVisitor: IGameBoardVisitor
    {
        internal IEnumerable<Position> Current { get; private set; }

        public void Visit(GameBoard board)
        {
            var current = new List<Position>();
            var size = board.BoardSize;
            for (int i = 0; i < board.InternalBoard.Length; i++)
            {
                current.Add(new Position
                {
                    X = i % size,
                    Y = i / size,
                    Player = board.InternalBoard[i] == default(char) ? null : (GameBoard.Player?)board.InternalBoard[i]
                });
            }
            Current = current;
        }
    }
}
