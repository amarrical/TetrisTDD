﻿//-----------------------------------------------------------------------
// <copyright file="Board.cs" company="ImprovingEnterprises">
//     Copyright (c) ImprovingEnterprises. All rights reserved.
// </copyright>
// <author>Patrick Sheehan</author>
//-----------------------------------------------------------------------
namespace TetrisTDD
{
    /// <summary>
    /// This is the board.  Treat it well.
    /// Note that StyleCop counts here, but tests don't care.
    /// </summary>
    public class Board
    {
        #region [ Fields ]

        /// <summary>
        /// Height of the current gameboard
        /// </summary>
        private int height;

        /// <summary>
        /// Width of the current gameboard
        /// </summary>
        private int width;

        /// <summary>
        /// Two-Dimensional array to represent the state of the board
        /// </summary>
        private char[,] boardArray;

        /// <summary>
        /// Represents if any Blocks are currently falling
        /// </summary>
        private bool hasFalling;

        #endregion

        #region [ Constructor ]
        
        /// <summary>
        /// Create a new board with the provided height and width
        /// </summary>
        /// <param name="height">The height of the game board</param>
        /// <param name="width">The width of the game board</param>
        public Board(int height, int width)
        {
            this.height = height;
            this.width = width;
            this.boardArray = new char[height, width];
            this.ClearBoard();
        }

        #endregion

        #region [ Methods ]

        /// <summary>
        /// Returns a string representation of the tetris board
        /// </summary>
        /// <returns>A string of ASCII Art to represent the board</returns>
        public override string ToString()
        {
            string boardString = "";
            for (int row = 0; row < height; row++)
            {
                for (int col = 0; col < width; col++)
                {
                    boardString = string.Concat(boardString, boardArray[row, col]);
                }
                boardString = string.Concat(boardString, "\n");
            }
            return boardString;
        }

        /// <summary>
        /// Returns a bool indicating if any game pieces are currently falling
        /// </summary>
        /// <returns>true if game pieces are currently falling, false otherwise</returns>
        public bool HasFalling()
        {
            return this.hasFalling;
        }

        /// <summary>
        /// Drop a new block into this game board
        /// </summary>
        /// <param name="block">The new block to drop into the board</param>
        public void Drop(Block block)
        {
            if (this.hasFalling)
            {
                throw new System.InvalidOperationException("A block is already falling");
            }
            int middleColumn = (width - 1) / 2;
            boardArray[0, middleColumn] = block.blockChar;
            this.hasFalling = true;
        }

        /// <summary>
        /// Drop a new block into this game board
        /// </summary>
        /// <param name="block">The char representation of a new block to drop into the board</param>
        public void Drop(char block)
        {
            Block b = new Block(block);
            this.Drop(b);
        }

        /// <summary>
        /// Advances the state of the board by one unit of time
        /// </summary>
        public void Tick()
        {
            int numDrops = 0;
            for (int r = height - 2; r >= 0; r--)
            {
                for (int c = 0; c < width; c++)
                {
                    if (boardArray[r, c] != '.' && boardArray[r + 1, c] == '.')
                    {
                        boardArray[r + 1, c] = boardArray[r, c];
                        boardArray[r, c] = '.';
                        numDrops++;
                    }
                }
            }
            if (numDrops == 0)
            {
                this.hasFalling = false;
            }
        }

        #endregion

        #region [ Private Helpers ]

        /// <summary>
        /// Clears all spaces on the board
        /// </summary>
        private void ClearBoard()
        {
            for (int row = 0; row < height; row++)
            {
                for (int col = 0; col < width; col++)
                {
                    boardArray[row, col] = '.';
                }
            }
        }

        #endregion
    }
}
