using CrossAndCircle.GameEngine;
using System.Linq;

namespace CrossAndCircle.UI.Blazor.App
{
    public class WebPlayer : Player 
    {
        public WebPlayer(GameBoard.Player playerId) : base(playerId)
        {
        }

        public void Move(int i, int j)
        {
            if (Board.CanMove(i, j))
            {
                Board.Move(Id, i, j);
            }
        }
    }
}
