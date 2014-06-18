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
        /// Represents the current <c>Tetromino</c> that is falling
        /// </summary>
        private Tetromino fallingTetromino;

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
        /// Moves the current falling <c>Tetromino</c> according to the MoveDirection
        /// </summary>
        /// <param name="direction">The direction to move the falling <c>Tetromino</c></param>
        /// <returns>True on success, false otherwise</returns>
        public bool MovePiece(MoveDirection direction)
        {
            if (this.fallingTetromino == null || !this.hasFalling)
            {
                return false;
            }

            this.Remove(this.fallingTetromino);
            Location originalLoc = this.fallingTetromino.Location;
            Location newLoc = originalLoc;
            if (direction == MoveDirection.Left)
            {
                newLoc = new Location(originalLoc.X - 1, originalLoc.Y);
            }
            else if (direction == MoveDirection.Right)
            {
                newLoc = new Location(originalLoc.X + 1, originalLoc.Y);
            }
            else if (direction == MoveDirection.Down)
            {
                newLoc = new Location(originalLoc.X, originalLoc.Y + 1);
            }

            this.hasFalling = this.Place(this.fallingTetromino, newLoc);
            
            if (!this.hasFalling)
            {
                this.Place(this.fallingTetromino, originalLoc);
            }

            return this.hasFalling;
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
            int tetHeight = tetromino.GetWidth();
            this.hasFalling = true;
            Location newLocation = new Location(midColumn, 0);
            this.Place(tetromino, newLocation);
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
            if (this.hasFalling && this.fallingTetromino != null)
            {
                this.hasFalling = this.MovePiece(MoveDirection.Down);

                if (!this.hasFalling)
                {
                    this.fallingTetromino = null;
                }
            }
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

        #region [ Override Methods ]

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

        #endregion

        #region [ Private Helpers ]

        /// <summary>
        /// Gets a Grid representation of a section of the board
        /// </summary>
        /// <param name="row">The row of the board to start from</param>
        /// <param name="column">The column of the board to start from</param>
        /// <param name="gridHeight">The height of the grid, the number of rows to copy</param>
        /// <param name="gridWidth">The width of the grid, the number of columns to copy</param>
        /// <returns>A Grid for a section of the board</returns>
        private Grid GetSubGrid(int row, int column, int gridHeight, int gridWidth)
        {
            if (row + gridHeight > this.height)
            {
                gridHeight = this.height - row;
            }

            if (column + gridWidth > this.width)
            {
                gridWidth = this.width - column;
            }

            Grid grid = new Grid(gridHeight, gridWidth);
            for (int i = 0; i < gridHeight; i++)
            {
                for (int j = 0; j < gridWidth; j++)
                {
                    grid.BlockArray[i, j] = this.blockArray[row + i, column + j];
                }
            }

            return grid;
        }

        /// <summary>
        /// Attempts to place a new <c>Tetromino</c> at the specified location on this game board
        /// </summary>
        /// <param name="tetromino">The <c>Tetromino</c> to be placed</param>
        /// <param name="location">The destination location on the game board</param>
        /// <returns>True on success, false otherwise</returns>
        private bool Place(Tetromino tetromino, Location location)
        {
            int tetWidth = tetromino.GetWidth();
            Grid grid = this.GetSubGrid(location.Y, location.X, tetWidth, tetWidth);

            if (grid != null && !grid.HasConflict(tetromino, 0, 0))
            {
                this.fallingTetromino = tetromino;
                tetromino.SetLocation(location);
                Piece tetPiece = new Piece(tetromino.ToString());

                for (int i = 0; i < tetWidth; i++)
                {
                    for (int j = 0; j < tetWidth; j++)
                    {
                        if (!tetPiece.PieceArray[i, j].IsEmpty() && i + location.Y < this.height && j + location.X < this.width)
                        {
                            this.blockArray[i + location.Y, j + location.X] = tetPiece.PieceArray[i, j];
                        }
                    }
                }

                return true;
            }

            return false;
        }

        /// <summary>
        /// Removes the given <c>Tetromino</c> from the board
        /// </summary>
        /// <param name="tetromino">The <c>Tetromino</c> to be removed</param>
        private void Remove(Tetromino tetromino)
        {
            Piece piece = new Piece(tetromino.ToString());
            for (int row = 0; row < tetromino.GetWidth(); row++)
            {
                for (int col = 0; col < tetromino.GetWidth(); col++)
                {
                    if (!piece.PieceArray[row, col].IsEmpty())
                    {
                        this.blockArray[row + tetromino.Location.Y, col + tetromino.Location.X].SetEmpty();
                    }
                }
            }
        }

        #endregion
    }
}
