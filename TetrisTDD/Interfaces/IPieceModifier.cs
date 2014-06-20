//-----------------------------------------------------------------------
// <copyright file="IPieceModifier.cs" company="ImprovingEnterprises">
//     Copyright (c) ImprovingEnterprises. All rights reserved.
// </copyright>
// <author>Patrick Sheehan</author>
//-----------------------------------------------------------------------
namespace TetrisTDD.Interfaces
{
    using System;
    using System.Collections.Generic;

    using TetrisTDD.Entities;
    using TetrisTDD.Enums;

    /// <summary>
    /// Handles the movement of a piece
    /// </summary>
    public interface IPieceModifier
    {
        /// <summary>
        /// Parses directions to determine new locations
        /// </summary>
        /// <param name="directions">The directions to be evaluated</param>
        /// <param name="location">The starting location for evaluation</param>
        /// <returns>The new locations</returns>
        IList<Location> ParseDirections(IEnumerable<Direction> directions, Location location);

        /// <summary>
        /// Parses direction to determine new location
        /// </summary>
        /// <param name="direction">The direction to be evaluated</param>
        /// <param name="location">The starting location for evaluation</param>
        /// <returns>The new location</returns>
        Location ParseDirection(Direction direction, Location location);
    }
}
