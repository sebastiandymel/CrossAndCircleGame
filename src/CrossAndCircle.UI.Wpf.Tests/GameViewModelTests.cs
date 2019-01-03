using CircleAndCross.UI.Wpf;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Globalization;

namespace CrossAndCircle.UI.Wpf.Tests
{
    [TestClass]
    public class GameViewModelTests
    {
        [TestMethod]
        public void GameViewModel_CreateNewGame()
        {
            var gvm = new GameViewModel();

            Assert.IsNotNull(gvm.Items);
            Assert.IsNotNull(gvm.StartGameCommand);
            Assert.IsFalse(gvm.IsGameRunning);
            gvm.StartGameCommand.Execute(null);

            Assert.AreEqual(9, gvm.Items.Count);
            Assert.IsTrue(gvm.IsGameRunning);
        }

        [TestMethod]
        public void GameViewModel_CanMove()
        {
            var gvm = new GameViewModel();
            gvm.StartGameCommand.Execute(null);
            Assert.AreEqual(9, gvm.Items.Count);
            foreach (var item in gvm.Items)
            {
                Assert.IsTrue(item.CanExecute(null));
            }
        }

        [TestMethod]
        public void GameViewModel_CannotMoveSamePosition()
        {
            var gvm = new GameViewModel();
            gvm.StartGameCommand.Execute(null);
            gvm.Items[0].Execute(null);
            Assert.IsFalse(gvm.Items[0].CanExecute(null));
        }

        [TestMethod]
        public void GameViewModel_HasModes()
        {
            var gvm = new GameViewModel();
            Assert.IsNotNull(gvm.Modes);
            Assert.AreEqual(2, gvm.Modes.Count);
        }

        [TestMethod]
        public void GameViewModel_CanStart1vs1Game()
        {
            var gvm = new GameViewModel();
            gvm.SelectedMode = GameMode.Player_vs_Player;
            gvm.StartGameCommand.Execute(null);
            gvm.Items[0].Execute(null);
            gvm.Items[1].Execute(null);

            Assert.AreNotEqual(PositionType.Empty, gvm.Items[0].Occupation);
            Assert.AreNotEqual(PositionType.Empty, gvm.Items[1].Occupation);
            Assert.AreNotEqual(gvm.Items[0].Occupation, gvm.Items[1].Occupation);
        }

        [TestMethod]
        public void GameViewModel_WinGame()
        {
            var gvm = new GameViewModel();
            gvm.StartGameCommand.Execute(null);
            gvm.Items[0].Execute(null);
            gvm.Items[3].Execute(null);
            gvm.Items[4].Execute(null);
            gvm.Items[8].Execute(null);

            Assert.IsTrue(gvm.Items[0].WinningPosition);
            Assert.IsTrue(gvm.Items[4].WinningPosition);
            Assert.IsTrue(gvm.Items[8].WinningPosition);
            Assert.IsFalse(gvm.IsGameRunning);
        }

        [TestMethod]
        public void NegateBoolTest()
        {
            var converter = new NegateBoolConverter();
            var result = converter.Convert(false, typeof(bool), null, CultureInfo.CurrentCulture);
            Assert.IsTrue((bool)result);
        }
    }
}
