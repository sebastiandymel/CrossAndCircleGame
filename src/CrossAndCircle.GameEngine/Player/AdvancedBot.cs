using System.Collections.Generic;
using System.Linq;

namespace CrossAndCircle.GameEngine
{
    public class AdvancedBot : Player
    {
        private WinningSchemas winningSchemas;

        public AdvancedBot(GameBoard.Player playerId) : base(playerId)
        {

        }

        public override void RequestNextMove()
        {
            base.RequestNextMove();

            if (this.winningSchemas == null)
            {
                this.winningSchemas = new WinningSchemas(Board.BoardSize);
            }

            // 
            // Block winning moves of other player
            //
            List<int> otherPlayerChecked = new List<int>();
            var otherPlayerId = Id.Other();
            for (int x = 0; x < Board.InternalBoard.Length; x++)
            {
                if (Board.InternalBoard[x] == (char)(otherPlayerId))
                {
                    otherPlayerChecked.Add(x);
                }
            }

            if (otherPlayerChecked.Count >= 2)
            {
                for (int i = 0; i < Board.BoardSize; i++)
                {
                    for (int j = 0; j < Board.BoardSize; j++)
                    {
                        if (Board.CanMove(i, j))
                        {
                            var toCheck = otherPlayerChecked.ToList();
                            toCheck.Add(ToBoardIndex(i, j));
                            if (this.winningSchemas.Contains(toCheck.ToArray(), out var _))
                            {
                                Board.Move(Id, i, j);
                                return;
                            }
                        }
                    }
                }
            }
            
            for (int i = 0; i < Board.BoardSize; i++)
            {
                for (int j = 0; j < Board.BoardSize; j++)
                {
                    if (Board.CanMove(i, j))
                    {
                        Board.Move(Id, i, j);
                        return;
                    }
                }
            }
        }

        private int ToBoardIndex(int x, int y)
        {
            return Board.BoardSize * y + x;
        }
    }
}
