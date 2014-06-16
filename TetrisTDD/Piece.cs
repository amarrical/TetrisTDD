//-----------------------------------------------------------------------
// <copyright file="Piece.cs" company="ImprovingEnterprises">
//     Copyright (c) ImprovingEnterprises. All rights reserved.
// </copyright>
// <author>Patrick Sheehan</author>
//-----------------------------------------------------------------------
namespace TetrisTDD
{
    using System;
 
    /// <summary>
    /// The possible directions for rotation of this piece
    /// </summary>
    public enum RotationDirection 
                { 
                    Right, 
                    Left 
                }

    /// <summary>
    /// Used to represent a cluster of Blocks
    /// </summary>
    public class Piece
    {
        #region [ Fields ]

        /// <summary>
        /// Represents this piece as a 2D array of Blocks
        /// </summary>
        private Block[,] pieceArray;

        /// <summary>
        /// The height and width of this piece
        /// </summary>
        private int sideLength;

        #endregion

        #region [ Constructor ]

        /// <summary>
        /// Constructs a new (square) Piece 
        /// </summary>
        /// <param name="piece">A string representation of the piece</param>
        public Piece(string piece)
        {
            string pieceWithoutNewLines = piece.Replace("\n", string.Empty);
            int numChars = pieceWithoutNewLines.Length;
            bool isSquare = Math.Sqrt(numChars) % 1 == 0;
            if (isSquare)
            {
                this.sideLength = (int)Math.Sqrt(numChars);
                this.pieceArray = new Block[this.sideLength, this.sideLength];

                for (int r = 0; r < this.sideLength; r++)
                {
                    for (int c = 0; c < this.sideLength; c++)
                    {
                        char blockChar = pieceWithoutNewLines[(this.sideLength * r) + c];
                        this.pieceArray[r, c] = new Block(blockChar);
                    }
                }
            }
            else
            { 
                throw new System.InvalidOperationException("A Piece must have equal side lengths");
            }
        }
        
        #endregion

        #region [ Methods ]

        /// <summary>
        /// Rotates this piece according to the provided direction
        /// </summary>
        /// <param name="direction">The direction to rotate the piece</param>
        public void Rotate(RotationDirection direction)
        {
            if (direction == RotationDirection.Right)
            {
                this.pieceArray = RotateRight(this.pieceArray, this.sideLength);
            }
            else if (direction == RotationDirection.Left)
            {
                this.pieceArray = RotateLeft(this.pieceArray, this.sideLength);
            }
        }

        /// <summary>
        /// Returns a string representation of this piece
        /// </summary>
        /// <returns>A string of ASCII Art to represent the piece</returns>
        public override string ToString()
        {
            string pieceString = string.Empty;
            for (int row = 0; row < this.sideLength; row++)
            {
                for (int col = 0; col < this.sideLength; col++)
                {
                    pieceString = string.Concat(pieceString, this.pieceArray[row, col].BlockChar);
                }

                pieceString = string.Concat(pieceString, "\n");
            }

            return pieceString;
        }

        /// <summary>
        /// Returns a deep copy of this Piece
        /// </summary>
        /// <returns>A copy of this Piece</returns>
        public Piece Clone()
        {
            string stringCopy = this.ToString();
            return new Piece(stringCopy);
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
