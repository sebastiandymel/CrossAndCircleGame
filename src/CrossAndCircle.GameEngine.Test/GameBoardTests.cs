using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CrossAndCircle.GameEngine.Test
{
    [TestClass]
    public class GameBoardTests
    {
        [TestMethod]
        public void Game_3x3_CanMoveToEmpty()
        {
            var game = GameBoardFactory.Create(3);

            Assert.IsTrue(game.CanMove(0, 0));
            Assert.IsTrue(game.CanMove(2, 2));
            Assert.IsTrue(game.CanMove(2, 0));
            Assert.IsTrue(game.CanMove(0, 2));
        }

        [TestMethod]
        public void Game_3x3_MoveToEmpty()
        {
            var game = GameBoardFactory.Create(3);

            Assert.IsTrue(game.CanMove(0, 0));
            game.Move(GameBoard.Player.Circle, 0, 0);
            Assert.IsFalse(game.CanMove(0, 0));
        }

        [TestMethod]
        public void Game_3x3_MoveToEmpty_EventRaised()
        {
            var moved = false;
            var game = GameBoardFactory.Create(3);
            game.PlayerMoved += (s, e) => { moved = true; };
            game.Move(GameBoard.Player.Circle, 0, 0);
            Assert.IsTrue(moved);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Game_3x3_ThrowsIfCantMove()
        {
            var game = GameBoardFactory.Create(3);

            Assert.IsTrue(game.CanMove(0, 0));
            game.Move(GameBoard.Player.Circle, 0, 0);
            game.Move(GameBoard.Player.Cross, 0, 0);
        }

        [TestMethod]
        public void Game_3x3_Winner1()
        {
            bool won = false;
            var game = GameBoardFactory.Create(3);
            game.GameWon += (s, e) =>
            {
                Assert.AreEqual(GameBoard.Player.Circle, e.Player);
                won = true;
            };

            game.Move(GameBoard.Player.Circle, 0, 0)
                .Move(GameBoard.Player.Circle, 0, 1)
                .Move(GameBoard.Player.Circle, 0, 2);

            Assert.IsTrue(won);
        }

        [TestMethod]
        public void Game_3x3_Winner2()
        {
            bool won = false;
            var game = GameBoardFactory.Create(3);
            game.GameWon += (s, e) =>
            {
                Assert.AreEqual(GameBoard.Player.Cross, e.Player);
                won = true;
            };
            game.Move(GameBoard.Player.Cross, 0, 1);
            game.Move(GameBoard.Player.Cross, 1, 1);
            game.Move(GameBoard.Player.Cross, 2, 1);

            Assert.IsTrue(won);
        }

        [TestMethod]
        public void Game_3x3_Winner3()
        {
            bool won = false;
            var game = GameBoardFactory.Create(3);
            game.GameWon += (s, e) =>
            {
                Assert.AreEqual(GameBoard.Player.Cross, e.Player);
                won = true;
            };
            game.Move(GameBoard.Player.Cross, 0, 0);
            game.Move(GameBoard.Player.Cross, 1, 1);
            game.Move(GameBoard.Player.Cross, 2, 2);

            Assert.IsTrue(won);
        }

        [TestMethod]
        public void Game_3x3_IsGameOver()
        {
            bool won = false;
            var game = GameBoardFactory.Create(3);
            game.GameWon += (s, e) =>
            {
                won = true;
            };

            //    0   1   2
            // 0 [x] [o] [x]
            // 1 [o] [o] [x]
            // 2 [x] [x] [o]

            game.Move(GameBoard.Player.Cross, 0, 0)
                .Move(GameBoard.Player.Circle, 0, 1)
                .Move(GameBoard.Player.Cross, 0, 2)
                .Move(GameBoard.Player.Circle, 1, 0)
                .Move(GameBoard.Player.Circle, 1, 1)
                .Move(GameBoard.Player.Cross, 1, 2)
                .Move(GameBoard.Player.Cross, 2, 0)
                .Move(GameBoard.Player.Cross, 2, 1)
                .Move(GameBoard.Player.Circle, 2, 2);

            Assert.IsTrue(game.IsGameOver);
            Assert.IsFalse(won);
        }

        [TestMethod]
        public void Game_3x3_IsGameOver2()
        {
            bool won = false;
            var game = GameBoardFactory.Create(3);
            game.GameWon += (s, e) =>
            {
                Assert.AreEqual(GameBoard.Player.Cross, e.Player);
                won = true;
            };

            //    0   1   2
            // 0 [x] [o] [x]
            // 1 [o] [o] [x]
            // 2 [ ] [ ] [x]

            game.Move(GameBoard.Player.Cross, 0, 0)
                .Move(GameBoard.Player.Circle, 0, 1)
                .Move(GameBoard.Player.Cross, 0, 2)
                .Move(GameBoard.Player.Circle, 1, 0)
                .Move(GameBoard.Player.Circle, 1, 1)
                .Move(GameBoard.Player.Cross, 1, 2)
                .Move(GameBoard.Player.Cross, 2, 2);

            Assert.IsTrue(game.IsGameOver);
            Assert.IsTrue(won);
        }

        [TestMethod]
        public void Game_2x2_SmokeTest()
        {
            var won = false;
            var game = GameBoardFactory.Create(2);
            game.GameWon += (s, e) =>
            {
                Assert.AreEqual(GameBoard.Player.Circle, e.Player);
                won = true;
            };

            game.Move(GameBoard.Player.Circle, 0, 0)
                .Move(GameBoard.Player.Cross, 1, 0)
                .Move(GameBoard.Player.Circle, 0, 1);

            Assert.IsTrue(won);
            Assert.IsTrue(game.IsGameOver);
        }
    }
}
