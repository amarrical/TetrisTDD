//-----------------------------------------------------------------------
// <copyright file="Block.cs" company="ImprovingEnterprises">
//     Copyright (c) ImprovingEnterprises. All rights reserved.
// </copyright>
// <author>Patrick Sheehan</author>
//-----------------------------------------------------------------------
namespace TetrisTDD.Entities
{
    using System.Linq;

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

        #region [ Methods ]

        /// <summary>
        /// Returns true if this is an empty block
        /// </summary>
        /// <returns>True if block is empty, false otherwise</returns>
        public bool IsEmpty()
        {
            return this.BlockChar == '.';
        }

        /// <summary>
        /// Assigns an empty value to this Block
        /// </summary>
        public void SetEmpty()
        {
            this.BlockChar = '.';
        }

        /// <summary>
        /// Returns a clone of this block
        /// </summary>
        /// <returns>A clone of this block</returns>
        public Block Clone()
        {
            return new Block(this.BlockChar);
        }
        #endregion
    }
}
