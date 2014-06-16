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
    public enum TetrominoShape 
                { 
                    T_SHAPE, 
                    I_SHAPE, 
                    O_SHAPE 
                }

    /// <summary>
    /// Represents the current orientation of a Tetromino
    /// </summary>
    public enum Orientation 
                {
                    A, 
                    B,
                    C,
                    D 
                }

    /// <summary>
    /// Represents one of many possible Tetris game pieces
    /// </summary>
    public class Tetromino
    {
        #region [ Fields ]

        /// <summary>
        /// The string representation of a T_SHAPE tetromino at its initial orientation
        /// </summary>
        private const string T_SHAPE_STRING_A = ".T.\nTTT\n...\n";

        /// <summary>
        /// The string representation of a T_SHAPE tetromino at 90 degrees orientation
        /// </summary>
        private const string T_SHAPE_STRING_B = ".T.\n.TT\n.T.\n";

        /// <summary>
        /// The string representation of a T_SHAPE tetromino at 180 degrees orientation
        /// </summary>
        private const string T_SHAPE_STRING_C = "...\nTTT\n.T.\n";

        /// <summary>
        /// The string representation of a T_SHAPE tetromino at 270 degrees orientation
        /// </summary>
        private const string T_SHAPE_STRING_D = ".T.\nTT.\n.T.\n";

        /// <summary>
        /// The string representation of an I_SHAPE tetromino when horizontal
        /// </summary>
        private const string I_SHAPE_STRING_HORIZONTAL = ".....\n.....\nIIII.\n.....\n.....\n";

        /// <summary>
        /// The string representation of an I_SHAPE tetromino when vertical
        /// </summary>
        private const string I_SHAPE_STRING_VERTICAL = "..I..\n..I..\n..I..\n..I..\n.....\n";

        /// <summary>
        /// The shape representation of this Tetromino
        /// </summary>
        private TetrominoShape currentShape;

        /// <summary>
        /// The current orientation of the Tetromino
        /// </summary>
        private Orientation currentOrientation;

        #endregion

        #region [ Constructors ]

        /// <summary>
        /// Constructs a Tetromino given a shape from the TetrominoShape enum
        /// </summary>
        /// <param name="shape">A shape from the TetrominoShape enum</param>
        public Tetromino(TetrominoShape shape)
        {
            this.currentShape = shape;
            this.currentOrientation = Orientation.A;
        }

        /// <summary>
        /// Constructs a Tetromino given a shape from the TetrominoShape enum
        /// </summary>
        /// <param name="shape">A shape from the TetrominoShape enum</param>
        /// <param name="orientation">The orientation to assign to this Tetromino</param>
        public Tetromino(TetrominoShape shape, Orientation orientation)
        {
            this.currentShape = shape;
            this.currentOrientation = orientation;
        }

        #endregion

        #region [ Methods ]

        /// <summary>
        /// Gets a string representation of this Tetromino
        /// </summary>
        /// <returns>A string representation</returns>
        public override string ToString()
        {
            return this.GetShapeString();
        }

        /// <summary>
        /// Rotates this Tetromino 90 degrees clockwise
        /// </summary>
        public Tetromino RotateRight()
        {
            Orientation newOrientation = (Orientation)(((int)this.currentOrientation + 1) % 4);
            return new Tetromino(this.currentShape, newOrientation);
        }

        /// <summary>
        /// Rotates this Tetromino 90 degrees counterclockwise
        /// </summary>
        public Tetromino RotateLeft()
        {
            Orientation newOrientation = (Orientation)(((int)this.currentOrientation + 3) % 4);
            return new Tetromino(this.currentShape, newOrientation);
        }

        #endregion

        #region [ Private Helpers ]

        /// <summary>
        /// Gets the appropriate string for a TetrominoShape
        /// </summary>
        /// <param name="shape">That shape to get a string representation of</param>
        /// <returns>A string representation of the shape</returns>
        private string GetShapeString()
        {
            TetrominoShape shape = this.currentShape;
            Orientation orientation = this.currentOrientation;

            switch (shape)
            {
                case TetrominoShape.T_SHAPE:
                {
                    switch (orientation)
                    {
                        case Orientation.A: return T_SHAPE_STRING_A;
                        case Orientation.B: return T_SHAPE_STRING_B;
                        case Orientation.C: return T_SHAPE_STRING_C;
                        case Orientation.D: return T_SHAPE_STRING_D;
                        default: return string.Empty;
                    }
                }

                case TetrominoShape.I_SHAPE:
                {
                    switch (orientation)
                    {
                        case Orientation.A: return I_SHAPE_STRING_HORIZONTAL;
                        case Orientation.B: return I_SHAPE_STRING_VERTICAL;
                        case Orientation.C: return I_SHAPE_STRING_HORIZONTAL;
                        case Orientation.D: return I_SHAPE_STRING_VERTICAL;
                        default: return string.Empty;
                    }
                }

                default: return string.Empty;
            }
        }
        #endregion
    }
}
