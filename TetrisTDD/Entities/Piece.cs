//-----------------------------------------------------------------------
// <copyright file="Piece.cs" company="ImprovingEnterprises">
//     Copyright (c) ImprovingEnterprises. All rights reserved.
// </copyright>
// <author>Patrick Sheehan</author>
//-----------------------------------------------------------------------
namespace TetrisTDD.Entities
{
    using System;
    using TetrisTDD.Enums;
 
    /// <summary>
    /// Used to represent a cluster of Blocks
    /// </summary>
    public class Piece
    {
        #region [ Constructor ]

        /// <summary>
        /// Initializes a new instance of the <see cref="Piece"/> class
        /// </summary>
        /// <param name="piece">A string representation of the piece</param>
        public Piece(string piece)
        {
            string pieceWithoutNewLines = piece.Replace("\n", string.Empty);
            int numChars = pieceWithoutNewLines.Length;
            bool isSquare = Math.Sqrt(numChars) % 1 == 0;
            if (isSquare)
            {
                this.SideLength = (int)Math.Sqrt(numChars);
                this.PieceArray = new Block[this.SideLength, this.SideLength];

                for (int r = 0; r < this.SideLength; r++)
                {
                    for (int c = 0; c < this.SideLength; c++)
                    {
                        char blockChar = pieceWithoutNewLines[(this.SideLength * r) + c];
                        Block block = new Block(blockChar);
                        this.PieceArray[r, c] = block;
                    }
                }
            }
            else
            { 
                throw new System.InvalidOperationException("A Piece must have equal side lengths");
            }
        }
        
        #endregion

        #region [ Fields ]

        /// <summary>
        /// Gets the 2D array of Blocks that represents this piece
        /// </summary>
        public Block[,] PieceArray { get; private set; }

        /// <summary>
        /// Gets the height and width of this piece
        /// </summary>
        public int SideLength { get; private set; }

        #endregion

        #region [ Methods ]

        /// <summary>
        /// Rotates this piece according to the provided direction
        /// </summary>
        /// <param name="direction">The direction to rotate the piece</param>
        public void Rotate(Rotation direction)
        {
            if (direction == Rotation.Clockwise)
            {
                this.PieceArray = RotateRight(this.PieceArray, this.SideLength);
            }
            else if (direction == Rotation.Counterclockwise)
            {
                this.PieceArray = RotateLeft(this.PieceArray, this.SideLength);
            }
        }

        /// <summary>
        /// Returns a string representation of this piece
        /// </summary>
        /// <returns>A string of ASCII Art to represent the piece</returns>
        public override string ToString()
        {
            string pieceString = string.Empty;
            for (int row = 0; row < this.SideLength; row++)
            {
                for (int col = 0; col < this.SideLength; col++)
                {
                    pieceString = string.Concat(pieceString, this.PieceArray[row, col].BlockChar);
                }

                pieceString = string.Concat(pieceString, "\n");
            }

            return pieceString;
        }

        #endregion

        #region [ Private Helpers ]

        /// <summary>
        /// Rotates the matrix 90 degrees clockwise
        /// </summary>
        /// <param name="matrix">The array to be rotated</param>
        /// <param name="n">The array's side lengths</param>
        /// <returns>The rotated version of the array</returns>
        private static Block[,] RotateRight(Block[,] matrix, int n)
        {
            Block[,] ret = new Block[n, n];

            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    ret[i, j] = matrix[n - j - 1, i];
                }
            }

            return ret;
        }

        /// <summary>
        /// Rotates the matrix 90 degrees counterclockwise
        /// </summary>
        /// <param name="matrix">The array to be rotated</param>
        /// <param name="n">The array's side lengths</param>
        /// <returns>The rotated version of the array</returns>
        private static Block[,] RotateLeft(Block[,] matrix, int n)
        {
            Block[,] ret = new Block[n, n];

            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    ret[n - j - 1, i] = matrix[i, j];
                }
            }

            return ret;
        }

        #endregion
    }
}
