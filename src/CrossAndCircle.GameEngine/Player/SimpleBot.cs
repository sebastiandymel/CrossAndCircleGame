namespace CrossAndCircle.GameEngine
{
    public class SimpleBot : Player
    {
        public SimpleBot(GameBoard.Player playerId) : base(playerId)
        {
        }

        public override void RequestNextMove()
        {
            base.RequestNextMove();

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
    }
}
