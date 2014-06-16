//-----------------------------------------------------------------------
// <copyright file="Block.cs" company="ImprovingEnterprises">
//     Copyright (c) ImprovingEnterprises. All rights reserved.
// </copyright>
// <author>Patrick Sheehan</author>
//-----------------------------------------------------------------------
namespace TetrisTDD
{
    /// <summary>
    /// Used to represent a single block in Tetris
    /// </summary>
    public class Block
    {
        #region [ Constructor ]
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Block"/> class
        /// </summary>
        /// <param name="blockChar">The char used to represent this block</param>
        public Block(char blockChar)
        {
            this.BlockChar = blockChar;
        }
        #endregion

        #region [ Fields ]

        /// <summary>
        /// Gets the char that represents this block
        /// </summary>
        public char BlockChar { get; private set; }

        #endregion
    }
}
