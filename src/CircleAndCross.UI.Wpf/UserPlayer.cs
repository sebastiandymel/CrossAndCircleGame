using CrossAndCircle.GameEngine;

namespace CircleAndCross.UI.Wpf
{
    public class UserPlayer : Player
    {
        public UserPlayer(GameBoard.Player playerId) : base(playerId)
        {
        }
        public void DoMove(int x, int y)
        {
            Board.Move(Id, x, y);
        }
        public bool CanMoveTo(int x, int y)
        {
            return Board.CanMove(x, y);
        }
    }
}
