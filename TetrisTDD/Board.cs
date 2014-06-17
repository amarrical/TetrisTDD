//-----------------------------------------------------------------------
// <copyright file="Board.cs" company="ImprovingEnterprises">
//     Copyright (c) ImprovingEnterprises. All rights reserved.
// </copyright>
// <author>Christopher Nolan</author>
//-----------------------------------------------------------------------
namespace TetrisTDD
{
    using System;
    using System.Collections.Generic;
    using System.IO; 
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    /// <summary>    using System;
    /// This is the board.  Treat it well.
    /// Note that StyleCop counts here, but tests don't care.
    /// </summary>
    public class Board
    {
        #region [ fields ] 
        /// <summary>
        /// holds true if a block is currently dropping
        /// </summary>
        private bool isDropping = false; 

        /// <summary>
        /// The time keeping system of the program. 
        /// </summary>
        private int tick = 0; 

        /// <summary>
        /// An empty block for returning spaces in the board to empty. 
        /// </summary>
        private Block empty = new Block('.'); 

        /// <summary>
        /// A block holding a newline character.
        /// </summary>
        private Block newline = new Block('\n');

        /// <summary>
        /// An array of Blocks.
        /// </summary>
        private Block[,] map;

        #endregion 

        #region [ constructors ]
        /// <summary>
        /// Initializes a new instance of the <see cref="Board"/> class. 
        /// </summary>
        /// <param name="width">The x axis of the game board.</param>
        /// <param name="length">The y axis of the game board</param>
        public Board(int width, int length)
        {
            this.Width = width;
            this.Length = length;

            this.map = new Block[this.Width + 1, this.Length];

            for (int i = 0; i < this.Width; i++)
            {
                for (int j = 0; j < this.Length; j++)
                {
                    this.map[i, j] = this.empty;
                }

                for (int j = 0; j < this.Length; j++)
                {
                    this.map[this.Width, j] = this.newline;
                }
            }
        }
        #endregion 

        #region [ overrides ]
        /// <summary>
        /// Overrides the ToString function to convert members of a Board to a string
        /// </summary>
        /// <returns>returns the board in one string</returns>
        public override string ToString()
        {
            string linearBoard = string.Empty;
            for (int j = 0; j < this.Length; j++)
            {
                for (int i = 0; i <= this.Width; i++)
                {
                    linearBoard += this.map[i, j].shape; 
                }
            }

            return linearBoard; 
        }

        /// <summary>
        /// Another version of the Drop function. 
        /// </summary>
        /// <param name="shape">The shape of the Block to be dropped.</param>
        public void Drop(char shape)
        {
            Block block = new Block(shape);
            this.Drop(block);
        }

        #endregion

        #region [ interface ] 
        /// <summary>
        /// determines if the Board has falling blocks
        /// </summary>
        /// <returns>returns true or false depending if there are falling blocks. </returns>
        public bool HasFalling()
        {
            if (this.isDropping)
            {
                return true;
            }

            return false; 
        }

        /// <summary>
        /// Drops a Block onto a board object.
        /// </summary>
        /// <param name="block">a Block variable</param>
        public void Drop(Block block)
        {
            if (this.isDropping)
            {
                throw new IllegalStateException("already falling");
            }
            else
            {
                this.map[1, 0] = block;
                this.isDropping = true;
            }   
        }

        /// <summary>
        /// Iterates the time of the program.
        /// </summary>
        public void Tick()
        {
            int count = 0; 
            for (int i = this.Length; i > 1; i--)
            {
                if (this.map[1, i - 1] == this.empty)
                {
                    if (this.map[1, i - 2] != this.empty)
                    {
                        this.map[1, i - 1] = this.map[1, i - 2];
                        this.map[1, i - 2] = this.empty;
                        this.isDropping = true;
                        count++;
                    }
                }
            }

            if (count == 0)
            {
                this.isDropping = false;
            }

            this.tick++; 
        }

        #endregion 

        /// <summary>
        /// Gets or sets the width variable
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// Gets or sets the length variable
        /// </summary>
        public int Length { get; set; }
    }
}
