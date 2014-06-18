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
        /// Rotates the currently falling piece according to the specified direction
        /// </summary>
        /// <param name="direction">The direction to rotate the falling piece</param>
        /// <returns>True on success, false otherwise</returns>
        public bool Rotate(RotationDirection direction)
        {
            if (this.fallingTetromino == null || !this.hasFalling)
            {
                return false;
            }

            Tetromino rotatedTet = this.fallingTetromino.Rotate(direction);
            Location originalLocation = this.fallingTetromino.Location;
            Location locToLeft = new Location(originalLocation.X - 1, originalLocation.Y);
            Location locToRight = new Location(originalLocation.X + 1, originalLocation.Y);

            this.Remove(this.fallingTetromino);

            bool success = false;

            if (!success)
            {   // Try placing the rotated piece in the same location
                success = this.Place(rotatedTet, originalLocation);
                rotatedTet.SetLocation(originalLocation);
            }

            if (!success)
            {   // Try placing the rotated piece one block to the left
                success = this.Place(rotatedTet, locToLeft);
                rotatedTet.SetLocation(locToLeft);
            }

            if (!success)
            {   // Try placing the rotated piece one block to the right
                success = this.Place(rotatedTet, locToRight);
                rotatedTet.SetLocation(locToRight);
            }

            if (success)
            {   // Use the rotated Tetromino if it was placed successfully
                this.fallingTetromino = rotatedTet;
            }
            else
            {   // If all else fails, put the piece back in its original spot
                this.Place(this.fallingTetromino, originalLocation);
            }

            return success;
        }

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

            Location originalLoc = this.fallingTetromino.Location;
            Location newLoc = originalLoc;
            this.Remove(this.fallingTetromino);

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
                this.Remove(this.fallingTetromino);
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
        /// Performs a specified number of ticks on this Board
        /// </summary>
        /// <param name="numTicks">The number of ticks to perform</param>
        public void Ticks(int numTicks)
        {
            for (int i = 0; i < numTicks; i++)
            {
                this.Tick();
            }
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
                    int rowToCopy = row + i;
                    int colToCopy = column + j;
                    if (rowToCopy >= 0 && colToCopy >= 0)
                    {
                        grid.BlockArray[i, j] = this.blockArray[rowToCopy, colToCopy];
                    }
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

            if (grid != null && !grid.HasConflict(tetromino, new Location(0, 0)))
            {
                this.fallingTetromino = tetromino;
                tetromino.SetLocation(location);
                Piece tetPiece = new Piece(tetromino.ToString());

                for (int i = 0; i < tetWidth; i++)
                {
                    for (int j = 0; j < tetWidth; j++)
                    {
                        int rowToCopy = i + location.Y;
                        int colToCopy = j + location.X;
                        if (!tetPiece.PieceArray[i, j].IsEmpty())
                        {
                            if (rowToCopy < this.height
                                && rowToCopy >= 0
                                && colToCopy < this.width
                                && colToCopy >= 0)
                            {   // Tetromino's block is nonempty and in range, copy it
                                this.blockArray[rowToCopy, colToCopy] = tetPiece.PieceArray[i, j];
                            }
                            else
                            {   // Tetromino's block is nonemepty and out of range, cannot place it here
                                return false;
                            }
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
                    int rowToEmpty = row + tetromino.Location.Y;
                    int colToEmpty = col + tetromino.Location.X;
                    if (!piece.PieceArray[row, col].IsEmpty()
                        && rowToEmpty >= 0
                        && colToEmpty >= 0
                        && rowToEmpty < this.height
                        && colToEmpty < this.width)
                    {
                        this.blockArray[rowToEmpty, colToEmpty].SetEmpty();
                    }
                }
            }
        }

        #endregion
    }
}
