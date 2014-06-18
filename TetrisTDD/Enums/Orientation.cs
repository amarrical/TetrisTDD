//-----------------------------------------------------------------------
// <copyright file="Orientation.cs" company="ImprovingEnterprises">
//     Copyright (c) ImprovingEnterprises. All rights reserved.
// </copyright>
// <author>Patrick Sheehan</author>
//-----------------------------------------------------------------------
namespace TetrisTDD
{
    /// <summary>
    /// Represents the current orientation of a <c>Tetromino</c>
    /// </summary>
    public enum Orientation
    {
        /// <summary>
        /// Initial orientation
        /// </summary>
        A,

        /// <summary>
        /// Orientation after 90 degree rotation
        /// </summary>
        B,

        /// <summary>
        /// Orientation after 180 degree rotation
        /// </summary>
        C,

        /// <summary>
        /// Orientation after 270 degree rotation
        /// </summary>
        D
    }
}
