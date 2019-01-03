using CrossAndCircle.GameEngine;
using System;
using System.Linq;
using System.Threading;

namespace CrossAndCircle.UI.Console
{
    class Program
    {
        private static ManualResetEvent mre = new ManualResetEvent(false);
        private static GameQueue gameQueue = new GameQueue();

        static void Main(string[] args)
        {
            Do(() =>
            {
                Out("Welcome to Cross And Circle game....");
                Out("Select player. Type X or O:");
                var id = GetPlayerId();
                var player = new ConsolePlayer(id, mre);
                var game = GameFactory.CreateGameWithBot(player, player);
                Out("Game started");
                game.Start();
            });

            mre.WaitOne();
        }

        private static void Do(Action work)
        {
            gameQueue.Do(work);
        }

        private static void Out(string input)
        {
            System.Console.WriteLine(input);
        }

        private static GameBoard.Player GetPlayerId()
        {
            GameBoard.Player? ret = null;
            do
            {
                var userOption = System.Console.ReadKey();
                if (userOption.Key == System.ConsoleKey.X)
                {
                    ret = GameEngine.GameBoard.Player.Cross;
                }
                if (userOption.Key == System.ConsoleKey.O)
                {
                    ret = GameEngine.GameBoard.Player.Circle;
                }
            }
            while (ret == null);
            return ret.Value;
        }

        private class ConsolePlayer : Player, IGameStateObserver
        {
            private readonly ManualResetEvent mre;

            public ConsolePlayer(GameBoard.Player playerId, ManualResetEvent mre) : base(playerId)
            {
                this.mre = mre;
            }

            public void OnStateChanged(GameState newState)
            {
                Do(() => Redraw(newState));
            }


            private char PlayerChar(GameBoard.Player? pl)
            {
                return pl == GameBoard.Player.Circle ? 'O' : 'X';
            }

            private void Redraw(GameState newState)
            {
                System.Console.Clear();
                for (int i = 0; i < newState.Cols.Length; i++)
                {
                    for (int j = 0; j < newState.Rows.Length; j++)
                    {
                        if (newState.IsEmptyPosition(i, j))
                        {
                            System.Console.Write("[ ]\t");
                        }
                        else
                        {
                            var playerVal = newState[i, j];
                            System.Console.Write("[");
                            System.Console.Write(PlayerChar(playerVal));
                            System.Console.Write("]\t");
                        }
                    }
                    System.Console.WriteLine();
                }
            }

            public override void RequestNextMove()
            {
                base.RequestNextMove();
                Do(WaitForMove);
            }

            private void WaitForMove()
            {
                var isValid = false;
                do
                {
                    Out("Enter next position (x,y): ");
                    var nextPos = System.Console.ReadLine();
                    var split = nextPos.Split(',');
                    if (split.Length == 2 &&
                        int.TryParse(split[0], out var x) &&
                        int.TryParse(split[1], out var y))
                    {
                        if (Board.CanMove(x, y))
                        {
                            isValid = true;
                            Board.Move(Id, x, y);
                        }
                        else
                        {
                            Out("This move is not allowed!");
                        }
                    }
                    else
                    {
                        Out("Wrong position, try again.");
                    }
                }
                while (!isValid);
            }

            public void OnGameEnded(EndStatus status, Position[] winningPositions)
            {
                Do(() => 
                {
                    Out("GAME OVER!!!!!");
                    System.Console.Read();
                    this.mre.Set();
                });
            }
        }
    }
}
