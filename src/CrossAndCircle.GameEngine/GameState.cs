using System;
using System.Collections.Generic;
using System.Linq;

namespace CrossAndCircle.GameEngine
{
    public class GameState
    {
        public GameState(IEnumerable<Position> board)
        {
            Board = board;
        }
        public IEnumerable<Position> Board { get; }
        public bool IsEmpty() => Board.All(x => x.IsEmpty());
        public bool IsEmptyPosition(int x, int y)
        {
            return Board.Single(b => b.X == x && b.Y == y).IsEmpty();
        }
        public GameBoard.Player? this[int x, int y]
        {
            get
            {
                return Board.Single(b => b.X == x && b.Y == y).Player;
            }
        }
        public int[] Rows => Board.Select(x => x.Y).Distinct().ToArray();
        public int[] Cols => Board.Select(x => x.X).Distinct().ToArray();
        public void ForEach(Action<int,int, GameBoard.Player?> action)
        {             
            for (int i = 0; i < Cols.Length; i++)
            {
                for (int j = 0; j < Rows.Length; j++)
                {
                    action(i, j, this[i,j]);
                }
            }
        }
    }
}
