using System;
using System.Collections.Generic;
using System.Linq;

namespace CrossAndCircle.GameEngine
{
    /// <summary>
    /// Represents game board
    ///   0  1  2
    /// 0 [] [] []
    /// 1 [] [] []
    /// 2 [] [] []
    /// </summary>
    public class GameBoard
    {
        private readonly int size;
        private readonly WinningSchemas winningSchemas;
        private char[] board;
        private bool hasWinner = false;

        public GameBoard(int size, WinningSchemas winningSchemas)
        {
            this.size = size;
            this.winningSchemas = winningSchemas;
            ClearGame();
        }

        /// <summary>
        /// Returns true if there is empty place at x,y coordinates
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public bool CanMove(int x, int y)
        {
            return !hasWinner && board[ToBoardIndex(x, y)] == default(char);
        }
        
        /// <summary>
        /// Moves player at X,Y position
        /// </summary>
        /// <param name="player"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public GameBoard Move(Player player, int x, int y)
        {
            if (hasWinner)
            {
                throw new InvalidOperationException($"Game over, cannot move {player.ToString()} to position [{x}, {y}]");
            }
            if (!CanMove(x,y))
            {
                throw new InvalidOperationException($"Cannot move here, cannot move {player.ToString()} to position [{x}, {y}]");
            }

            this.board[ToBoardIndex(x, y)] = (char)player;

            CheckWinner(player);

            PlayerMoved(this, new PlayerMovedEventArgs(player));            

            return this;
        }

        public GameBoard ClearGame()
        {
            this.hasWinner = false;
            board = new char[size * size];
            BoardCleared(this, EventArgs.Empty);
            return this;
        }

        public event EventHandler<GameWonEventArgs> GameWon = delegate { };
        public event EventHandler GameTied = delegate { };
        public event EventHandler<PlayerMovedEventArgs> PlayerMoved = delegate { };
        public event EventHandler BoardCleared = delegate { };

        public bool IsGameOver => this.hasWinner || this.board.All(x => x != default(char));
        public int BoardSize => this.size;    
        
        internal void Accept(IGameBoardVisitor visitor)
        {
            visitor.Visit(this);
        }

        internal char[] InternalBoard => this.board.Clone() as char[];
        
        #region Private helpers

        private int ToBoardIndex(int x, int y)
        {
            return this.size * y + x;
        }

        private void CheckWinner(Player player)
        {
            List<int> @checked = new List<int>();
            for (int i = 0; i < board.Length; i++)
            {
                if (board[i] == (char)player)
                {
                    @checked.Add(i); 
                }
            }
            if (this.winningSchemas.Contains(@checked.ToArray(), out var winningpositions))
            {
                this.hasWinner = true;
                GameWon(this, new GameWonEventArgs(player, winningpositions));
            }
            else if (!hasWinner && board.All(x => x != default(char)))
            {
                GameTied(this, EventArgs.Empty);
            }
        }

        #endregion Private helpers

        public enum Player
        {
            Cross = (int)'X',
            Circle = (int)'O'
        }
    }
}
