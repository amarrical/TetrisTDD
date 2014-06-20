//-----------------------------------------------------------------------
// <copyright file="Direction.cs" company="ImprovingEnterprises">
//     Copyright (c) ImprovingEnterprises. All rights reserved.
// </copyright>
// <author>Patrick Sheehan</author>
//-----------------------------------------------------------------------
namespace TetrisTDD.Enums
{
    /// <summary>
    /// The possible movement directions for <c>Tetrominoes</c>
    /// </summary>
    public enum Direction
    {
        /// <summary>
        /// Left <c>Tetromino</c> movement
        /// </summary>
        Left,

        /// <summary>
        /// Right <c>Tetromino</c> movement
        /// </summary>
        Right,

        /// <summary>
        /// Downwards <c>Tetromino</c> movement
        /// </summary>
        Down,

        /// <summary>
        /// No <c>Tetromino</c> movement
        /// </summary>
        None
    }
}
