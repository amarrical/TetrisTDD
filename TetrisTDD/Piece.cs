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
    public enum RotationDirection { Right, Left };

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
            string pieceWithoutNewLines = piece.Replace("\n", "");
            int numChars = pieceWithoutNewLines.Length;
            bool isSquare = Math.Sqrt(numChars) % 1 == 0;
            if (isSquare)
            {
                sideLength = (int)Math.Sqrt(numChars); 
                pieceArray = new Block[sideLength, sideLength];

                for (int r = 0; r < sideLength; r++)
                {
                    for (int c = 0; c < sideLength; c++)
                    {
                        char blockChar = pieceWithoutNewLines[sideLength * r + c];
                        pieceArray[r, c] = new Block(blockChar);
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
                pieceArray = RotateRight(pieceArray, sideLength);
            }
            else if (direction == RotationDirection.Left)
            {
                pieceArray = RotateLeft(pieceArray, sideLength);
            }
        }

        /// <summary>
        /// Returns a string representation of this piece
        /// </summary>
        /// <returns>A string of ASCII Art to represent the piece</returns>
        public override string ToString()
        {
            string pieceString = "";
            for (int row = 0; row < sideLength; row++)
            {
                for (int col = 0; col < sideLength; col++)
                {
                    pieceString = string.Concat(pieceString, pieceArray[row, col].blockChar);
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
