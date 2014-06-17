//-----------------------------------------------------------------------
// <copyright file="Grid.cs" company="ImprovingEnterprises">
//     Copyright (c) ImprovingEnterprises. All rights reserved.
// </copyright>
// <author>Patrick Sheehan</author>
//-----------------------------------------------------------------------
namespace TetrisTDD
{
    /// <summary>
    /// Represents a grid of Blocks
    /// </summary>
    public class Grid
    {
        #region [ Fields ]

        /// <summary>
        /// Gets the height of this grid
        /// </summary>
        public int Height { get; private set; }

        /// <summary>
        /// Gets the width of this grid
        /// </summary>
        public int Width { get; private set; }

        /// <summary>
        /// Gets A 2D array of blocks that represent this grid
        /// </summary>
        public Block[,] BlockArray { get; private set; }

        #endregion

        #region [ Constructor ]

        /// <summary>
        /// Initializes a new instance of the <see cref="Grid"/> class
        /// </summary>
        /// <param name="height">the height of this grid</param>
        /// <param name="width">the width of this grid</param>
        public Grid(int height, int width)
        {
            this.Height = height;
            this.Width = width;
            this.BlockArray = new Block[height, width];
        }

        #endregion

        #region [ Methods ]

        /// <summary>
        /// Returns true if there is any overlap between the <c>Tetromino</c> and the existing blocks at the given location
        /// </summary>
        /// <param name="tetromino">The <c>Tetromino</c> to be checked</param>
        /// <param name="row">The row of the top left location where the <c>Tetromino</c> should be checked</param>
        /// <param name="column">The column of the top left location where the <c>Tetromino</c> should be checked</param>
        /// <returns>True if there is a conflict, false otherwise</returns>
        public bool HasConflict(Tetromino tetromino, int row, int column)
        {
            Piece piece = new Piece(tetromino.ToString());
            return this.HasConflict(piece, row, column);
        }

        /// <summary>
        /// Returns true if there is any overlap between the piece and the existing blocks at the given location
        /// </summary>
        /// <param name="piece">The Piece to be checked</param>
        /// <param name="row">The row of the location where the piece should be checked</param>
        /// <param name="column">The column of the location where the piece should be checked</param>
        /// <returns>True if there is a conflict, false otherwise</returns>
        public bool HasConflict(Piece piece, int row, int column)
        {
            int pieceLength = piece.SideLength;
            Block[,] pieceArray = piece.PieceArray;

            for (int i = 0; i < pieceLength; i++)
            {
                for (int j = 0; j < pieceLength; j++)
                {
                    if (!pieceArray[i, j].IsEmpty() 
                        && !this.BlockArray[row + i, column + j].IsEmpty())
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        #endregion
    }
}
