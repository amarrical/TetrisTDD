//-----------------------------------------------------------------------
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
        /// Height of the current game board
        /// </summary>
        private int height;

        /// <summary>
        /// Width of the current game board
        /// </summary>
        private int width;

        /// <summary>
        /// Two-Dimensional array of Blocks to represent the state of the board
        /// </summary>
        private Block[,] blockArray;

        /// <summary>
        /// Represents if any Blocks are currently falling
        /// </summary>
        private bool hasFalling;

        #endregion

        #region [ Constructor ]
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Board"/> class
        /// </summary>
        /// <param name="height">The height of the game board</param>
        /// <param name="width">The width of the game board</param>
        public Board(int height, int width)
        {
            this.height = height;
            this.width = width;
            this.blockArray = new Block[height, width];
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
            string boardString = string.Empty;
            for (int row = 0; row < this.height; row++)
            {
                for (int col = 0; col < this.width; col++)
                {
                    boardString = string.Concat(boardString, this.blockArray[row, col].BlockChar);
                }

                boardString = string.Concat(boardString, "\n");
            }

            return boardString;
        }

        /// <summary>
        /// Returns a boolean indicating if any game pieces are currently falling
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

            int middleColumn = (this.width - 1) / 2;
            this.blockArray[0, middleColumn] = block;
            this.hasFalling = true;
        }

        /// <summary>
        /// Drop a new <c>Tetromino</c> into this game board
        /// </summary>
        /// <param name="tetromino">The piece to be dropped</param>
        public void Drop(Tetromino tetromino)
        {
            int midColumn = (this.width - 1) / 2;
            this.Place(tetromino, 0, midColumn);
        }

        /// <summary>
        /// Drop a new block into this game board
        /// </summary>
        /// <param name="block">The char representation of a new block to drop into the board</param>
        public void Drop(char block)
        {
            this.Drop(new Block(block));
        }

        /// <summary>
        /// Advances the state of the board by one unit of time
        /// </summary>
        public void Tick()
        {
            int numDrops = 0;
            for (int r = this.height - 2; r >= 0; r--)
            {
                for (int c = 0; c < this.width; c++)
                {
                    if (!this.blockArray[r, c].IsEmpty() 
                        && this.blockArray[r + 1, c].IsEmpty())
                    {
                        this.blockArray[r + 1, c] = this.blockArray[r, c].Clone();
                        this.blockArray[r, c] = new Block('.');
                        numDrops++;
                    }
                }
            }

            this.hasFalling = numDrops > 0;
        }

        /// <summary>
        /// Clears all spaces on the board
        /// </summary>
        public void ClearBoard()
        {
            for (int row = 0; row < this.height; row++)
            {
                for (int col = 0; col < this.width; col++)
                {
                    this.blockArray[row, col] = new Block('.');
                }
            }
        }

        #endregion

        #region [ Private Helpers ]

        private Grid GetSubGrid(int row, int column, int height, int width)
        {
            Grid grid = new Grid(height, width);
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    grid.BlockArray[i, j] = this.blockArray[row + i, column + j];
                }
            }

            return grid;
        }

        /// <summary>
        /// Places a new <c>Tetromino</c> at a specific place on this game board
        /// </summary>
        /// <param name="tetromino">The <c>Tetromino</c> to be placed</param>
        /// <param name="row">The row of the game board (zero is at the top)</param>
        /// <param name="column">The column of the game board</param>
        private void Place(Tetromino tetromino, int row, int column)
        {
            int tetWidth = tetromino.GetWidth();
            Grid grid = this.GetSubGrid(row, column, tetWidth, tetWidth);
            bool conflict = grid.HasConflict(tetromino, 0, 0);
            
            if (!conflict)
            {
                tetromino.X = row;
                tetromino.Y = column;
                Piece tetPiece = new Piece(tetromino.ToString());

                for (int i = 0; i < tetWidth; i++)
                {
                    for (int j = 0; j < tetWidth; j++)
                    {
                        if (!tetPiece.PieceArray[i, j].IsEmpty())
                        {
                            this.blockArray[i + row, j + column] = tetPiece.PieceArray[i, j];
                        }
                    }
                }
            }
        }

        #endregion
    }
}
