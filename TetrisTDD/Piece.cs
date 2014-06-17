//-----------------------------------------------------------------------
// <copyright file="Piece.cs" company="ImprovingEnterprises">
//     Copyright (c) ImprovingEnterprises. All rights reserved.
// </copyright>
// <author>Christopher Nolan</author>
//-----------------------------------------------------------------------

namespace TetrisTDD
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// A piece that can be rotated
    /// </summary>
    public class Piece
    {
        #region [ constructor ]
        /// <summary>
        /// Initializes a new instance of the <see cref="Piece"/> class. 
        /// </summary>
        /// <param name="piece">A member of Piece that can be rotated</param>
        public Piece(string piece)
        {
            this.Piece = piece;
        }

        #endregion

        #region [ properties ]
        /// <summary>
        /// Gets or sets a piece variable
        /// </summary>
        public string Piece { get; set; }

        #endregion

        #region [ overrides ]
        /// <summary>
        /// Returns a piece in a string format
        /// </summary>
        /// <returns>The string format of the piece</returns>
        public override string ToString()
        {
            return this.Piece;
        }
        
        #endregion
  
        #region [ methods ]
        /// <summary>
        /// Rotates a piece (currently hard coded)
        /// </summary>
        /// <param name="direction"> The direction the piece will be rotated. </param>
        public void Rotate(RotationDirection direction)
        {
            if (Piece.Length == 30)
            {
                if (direction == RotationDirection.Right)
                {
                    this.Piece = ".....\n.....\n..XXX\n...XX\n....X\n";
                }

                if (direction == RotationDirection.Left)
                {
                    this.Piece = "X....\nXX...\nXXX..\n.....\n.....\n";
                }
            }
            else
            {
                if (direction == RotationDirection.Right)
                {
                    this.Piece = "...\n.XX\n...\n";
                }

                if (direction == RotationDirection.Left)
                {
                    this.Piece = "...\nXX.\n...\n";
                }
            }
        }
    }
}

        #endregion