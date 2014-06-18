//-----------------------------------------------------------------------
// <copyright file="Location.cs" company="ImprovingEnterprises">
//     Copyright (c) ImprovingEnterprises. All rights reserved.
// </copyright>
// <author>Patrick Sheehan</author>
//-----------------------------------------------------------------------
namespace TetrisTDD
{
    /// <summary>
    /// Represents a location 
    /// </summary>
    public class Location
    {
        #region [ Constructor ]

        /// <summary>
        /// Initializes a new instance of the <see cref="Location"/> class
        /// </summary>
        /// <param name="x">The x coordinate of the new location</param>
        /// <param name="y">The y coordinate of the new location</param>
        public Location(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        #endregion

        #region [ Fields ]

        /// <summary>
        /// Gets or sets the X coordinate of this location
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Gets or sets the Y coordinate of this location
        /// </summary>
        public int Y { get; set; }        

        #endregion
    }
}
