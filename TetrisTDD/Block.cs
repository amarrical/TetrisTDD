//-----------------------------------------------------------------------
// <copyright file="Block.cs" company="ImprovingEnterprises">
//     Copyright (c) ImprovingEnterprises. All rights reserved.
// </copyright>
// <author>Patrick Sheehan</author>
//-----------------------------------------------------------------------
namespace TetrisTDD
{
    public class Block
    {
         #region [ Fields ]

        /// <summary>
        /// Char that represents this block
        /// </summary>
        public char blockChar { get; private set; }

        #endregion

        #region [ Constructor ]
        
        /// <summary>
        /// Create a new block that is represented by blockChar
        /// </summary>
        /// <param name="blockChar">The char used to represent this block</param>
        public Block(char blockChar)
        {
            this.blockChar = blockChar;
        }

        #endregion

    }
}
