using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace CrossAndCircle.GameEngine.Test
{
    [TestClass]
    public class GameTests
    {
        private Game game;
        private TestObserver observer;
        private TestPlayer p1;
        private TestPlayer p2;
        [TestInitialize]
        public void TestInitialize()
        {
            var board = GameBoardFactory.Create(3);
            p1 = new TestPlayer(GameBoard.Player.Circle);
            p2 = new TestPlayer(GameBoard.Player.Cross);
            observer = new TestObserver();
            game = new Game(board, p1, p2, observer);
        }

        [TestMethod]
        public void Game_Start()
        {
            game.Start();

            Assert.AreEqual(1, observer.InvocationCount);
            Assert.IsNotNull(observer.Current);
            Assert.IsNotNull(observer.Current.Board);
            Assert.AreEqual(9, observer.Current.Board.Count());
        }

        [TestMethod]
        public void Game_CanWin()
        {
            game.Start();
            
            p1.Move(0, 0);
            p2.Move(1, 0);
            p1.Move(0, 1);
            p2.Move(1, 1);
            p1.Move(0, 2);
            Assert.AreEqual(EndStatus.CircleWins, observer.EndStatus);
        }

        [TestMethod]
        public void Game_CanMove()
        {
            game.Start();

            Assert.IsTrue(p1.CanMove);
            p1.Move(0, 0);
            Assert.IsFalse(p1.CanMove);
            Assert.IsTrue(p2.CanMove);
            p2.Move(1, 0);
            Assert.IsTrue(p1.CanMove);            
        }

        [TestMethod]
        public void Game_MoveRequested()
        {
            game.Start();
            Assert.AreEqual(1, p1.RequestNextMoveCount);
        }

        [TestMethod]
        public void Game_MoveRequest()
        {
            game.Start();
            Assert.AreEqual(1, p1.RequestNextMoveCount);
            Assert.IsTrue(observer.Current.IsEmptyPosition(2, 2));

            p1.Move(2, 2);

            Assert.AreEqual(2, observer.InvocationCount);
            Assert.IsFalse(observer.Current.IsEmptyPosition(2, 2));
            Assert.AreEqual(1, observer.Current.Board.Count(x => !x.IsEmpty()));
        }

        private class TestPlayer : Player
        {
            public TestPlayer(GameBoard.Player playerId) : base(playerId)
            {
            }

            public override void RequestNextMove()
            {
                base.RequestNextMove();
                RequestNextMoveCount++;
            }

            public void  Move(int x, int y)
            {
                Board.Move(Id, x, y);
            }

            public int RequestNextMoveCount { get; private set; }
        }

        private class TestObserver : IGameStateObserver
        {
            public GameState Current { get; private set; }
            public int InvocationCount { get; private set; }
            public EndStatus? EndStatus { get; private set; }
            public void OnGameEnded(EndStatus status, Position[] winningPositions)
            {
                EndStatus = status;
            }

            public void OnStateChanged(GameState newState)
            {
                Current = newState;
                InvocationCount++;
            }
        }
    }
}
