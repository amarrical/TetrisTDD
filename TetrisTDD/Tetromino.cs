//-----------------------------------------------------------------------
// <copyright file="Tetromino.cs" company="ImprovingEnterprises">
//     Copyright (c) ImprovingEnterprises. All rights reserved.
// </copyright>
// <author>Patrick Sheehan</author>
//-----------------------------------------------------------------------
namespace TetrisTDD
{
    /// <summary>
    /// Represents one of many possible Tetris game pieces
    /// </summary>
    public class Tetromino
    {
        #region [ Fields ]
        
        /// <summary>
        /// The string representation of a T_SHAPE <c>Tetromino</c> at its initial orientation
        /// </summary>
        private const string TShapeStringA = ".T.\nTTT\n...\n";

        /// <summary>
        /// The string representation of a T_SHAPE <c>Tetromino</c> at 90 degrees orientation
        /// </summary>
        private const string TShapeStringB = ".T.\n.TT\n.T.\n";

        /// <summary>
        /// The string representation of a T_SHAPE <c>Tetromino</c> at 180 degrees orientation
        /// </summary>
        private const string TShapeStringC = "...\nTTT\n.T.\n";

        /// <summary>
        /// The string representation of a T_SHAPE <c>Tetromino</c> at 270 degrees orientation
        /// </summary>
        private const string TShapeStringD = ".T.\nTT.\n.T.\n";

        /// <summary>
        /// The string representation of an I_SHAPE <c>Tetromino</c> when horizontal
        /// </summary>
        private const string IShapeStringHorizontal = ".....\n.....\nIIII.\n.....\n.....\n";

        /// <summary>
        /// The string representation of an I_SHAPE <c>Tetromino</c> when vertical
        /// </summary>
        private const string IShapeStringVertical = "..I..\n..I..\n..I..\n..I..\n.....\n";

        /// <summary>
        /// The string representation of an O_SHAPE <c>Tetromino</c>
        /// </summary>
        private const string OShapeString = ".OO\n.OO\n...\n";

        /// <summary>
        /// The shape representation of this <c>Tetromino</c>
        /// </summary>
        private TetrominoShape currentShape;

        /// <summary>
        /// The current orientation of the <c>Tetromino</c>
        /// </summary>
        private Orientation currentOrientation;

        /// <summary>
        /// Gets the current location of this <c>Tetromino</c>
        /// </summary>
        public Location Location { get; private set; }

        #endregion

        #region [ Constructors ]

        /// <summary>
        /// Initializes a new instance of the <see cref="Tetromino"/> class
        /// </summary>
        /// <param name="shape">A shape from the <c>TetrominoShape</c> <c>enum</c></param>
        public Tetromino(TetrominoShape shape)
        {
            this.currentShape = shape;
            this.currentOrientation = Orientation.A;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Tetromino"/> class
        /// </summary>
        /// <param name="shape">A shape from the <c>TetrominoShape</c> <c>enum</c></param>
        /// <param name="orientation">The orientation to assign to this <c>Tetromino</c></param>
        public Tetromino(TetrominoShape shape, Orientation orientation)
        {
            this.currentShape = shape;
            this.currentOrientation = orientation;
        }

        #endregion

        #region [ Methods ]

        /// <summary>
        /// Sets the location for this <c>Tetromino</c>
        /// </summary>
        /// <param name="x">The x coordinate</param>
        /// <param name="y">The y coordinate</param>
        public void SetLocation(int x, int y)
        {
            this.Location = new Location(x, y);
        }

        /// <summary>
        /// Sets the location for this <c>Tetromino</c>
        /// </summary>
        /// <param name="newLocation">The new location to be used</param>
        public void SetLocation(Location newLocation)
        {
            this.Location = newLocation;
        }

        /// <summary>
        /// Gets a string representation of this <c>Tetromino</c>
        /// </summary>
        /// <returns>A string representation</returns>
        public override string ToString()
        {
            return this.GetShapeString();
        }

        /// <summary>
        /// Rotates this <c>Tetromino</c> according to rotations in parameter
        /// </summary>
        /// <param name="rotations">The rotations to apply to this <c>Tetromino</c></param>
        /// <returns>A new <c>Tetromino</c> with the specified rotations</returns>
        public Tetromino Rotate(params RotationDirection[] rotations)
        {
            Orientation newOrientation = this.currentOrientation;

            foreach (RotationDirection rotation in rotations)
            {
                if (rotation == RotationDirection.Right)
                {
                    newOrientation = (Orientation)(((int)newOrientation + 1) % 4);
                }
                else if (rotation == RotationDirection.Left)
                {
                    newOrientation = (Orientation)(((int)newOrientation + 3) % 4);
                }
            }

            return new Tetromino(this.currentShape, newOrientation);
        }

        /// <summary>
        /// Gets the width of this <c>Tetromino's</c> enclosing square
        /// </summary>
        /// <returns>The width for this <c>Tetromino</c></returns>
        public int GetWidth()
        {
            switch (this.currentShape)
            {
                case TetrominoShape.O_SHAPE: return 3;
                case TetrominoShape.T_SHAPE: return 3;
                case TetrominoShape.I_SHAPE: return 5;
                default: break;
            }

            return -1;
        }

        #endregion

        #region [ Private Helpers ]

        /// <summary>
        /// Gets the appropriate string for this <c>Tetromino</c>
        /// </summary>
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
                        case Orientation.A: return TShapeStringA;
                        case Orientation.B: return TShapeStringB;
                        case Orientation.C: return TShapeStringC;
                        case Orientation.D: return TShapeStringD;
                        default: return string.Empty;
                    }
                }

                case TetrominoShape.I_SHAPE:
                {
                    switch (orientation)
                    {
                        case Orientation.A: return IShapeStringHorizontal;
                        case Orientation.B: return IShapeStringVertical;
                        case Orientation.C: return IShapeStringHorizontal;
                        case Orientation.D: return IShapeStringVertical;
                        default: return string.Empty;
                    }
                }

                case TetrominoShape.O_SHAPE: return OShapeString;

                default: return string.Empty;
            }
        }
        #endregion
    }
}
