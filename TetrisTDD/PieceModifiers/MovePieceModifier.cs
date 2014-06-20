//-----------------------------------------------------------------------
// <copyright file="MovePieceModifier.cs" company="ImprovingEnterprises">
//     Copyright (c) ImprovingEnterprises. All rights reserved.
// </copyright>
// <author>Patrick Sheehan</author>
//-----------------------------------------------------------------------
namespace TetrisTDD.PieceModifiers
{
    using System;
    using System.Collections.Generic;

    using TetrisTDD.Entities;
    using TetrisTDD.Enums;
    using TetrisTDD.Interfaces;

    /// <summary>
    /// Handles the movement of a piece
    /// </summary>
    public class MovePieceModifier : IPieceModifier
    {
        #region [ IPieceModifier Methods ]

        /// <summary>
        /// Parses directions and a location to calculate possible new locations
        /// </summary>
        /// <param name="directions">The directions to be evaluated</param>
        /// <param name="location">The starting location for evaluation</param>
        /// <returns>The new locations</returns>
        public IList<Location> ParseDirections(IEnumerable<Direction> directions, Location location)
        {
            IList<Location> retList = new List<Location>();

            foreach (var direction in directions)
            {
                retList.Add(this.ParseDirection(direction, location));
            }

            return retList;
        }

        /// <summary>
        /// Parses direction to determine new location
        /// </summary>
        /// <param name="direction">The direction to be evaluated</param>
        /// <param name="location">The starting location for evaluation</param>
        /// <returns>The new location</returns>
        public Location ParseDirection(Direction direction, Location location)
        {
            switch (direction)
            {
                case Direction.Left:
                    return new Location(location.X - 1, location.Y);
            
                case Direction.Right:
                    return new Location(location.X + 1, location.Y);
            
                case Direction.Down:
                    return new Location(location.X, location.Y + 1);
                
                default: return location;
            }
        }

        #endregion
    }
}
