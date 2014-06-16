//-----------------------------------------------------------------------
// <copyright file="Tetromino.cs" company="ImprovingEnterprises">
//     Copyright (c) ImprovingEnterprises. All rights reserved.
// </copyright>
// <author>Patrick Sheehan</author>
//-----------------------------------------------------------------------
namespace TetrisTDD
{
    /// <summary>
    /// Represents the type of shapes a Tetromino can represent
    /// </summary>
    public enum TetrominoShape { T_SHAPE , I_SHAPE, O_SHAPE };

    public class Tetromino
    {
        #region [ Fields ]

        /// <summary>
        /// The string representation of a T_SHAPE tetromino
        /// </summary>
        private static string T_SHAPE_STRING = ".T.\nTTT\n...\n";

        /// <summary>
        /// The piece used to represent this Tetromino shape
        /// </summary>
        private Piece piece;

        /// <summary>
        /// The shape representation of this Tetromino
        /// </summary>
        private TetrominoShape currentShape;

        #endregion

        #region [ Constructors ]

        public Tetromino(TetrominoShape shape)
        {
            currentShape = shape;
            piece = new Piece(getShapeString(shape));
        }

        public Tetromino(TetrominoShape shape, Piece newPiece)
        {
            currentShape = shape;
            this.piece = newPiece;
        }

        #endregion

        #region [ Methods ]

        public override string ToString()
        {
            return piece.ToString();
            //return getShapeString(currentShape);
        }
        /// <summary>
        /// Rotates this Tetromino 90 degrees clockwise
        /// </summary>
        public Tetromino RotateRight()
        {
            Piece pieceCopy = new Piece(piece.ToString());
            pieceCopy.Rotate(RotationDirection.Right);
            Tetromino ret = new Tetromino(currentShape, pieceCopy);
            return ret;
        }

        /// <summary>
        /// Rotates this Tetromino 90 degrees counterclockwise
        /// </summary>
        public Tetromino RotateLeft()
        {
            Piece pieceCopy = new Piece(piece.ToString());
            pieceCopy.Rotate(RotationDirection.Left);
            Tetromino ret = new Tetromino(currentShape, pieceCopy);
            return ret;
        }

        #endregion

        #region [ Private Helpers ]

        private string getShapeString(TetrominoShape shape)
        {
            switch (shape)
            {
                case TetrominoShape.T_SHAPE: return T_SHAPE_STRING;

                default: return "";
            }
        }
        #endregion
    }
}
