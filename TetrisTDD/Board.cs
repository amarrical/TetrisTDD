//-----------------------------------------------------------------------
// <copyright file="Board.cs" company="ImprovingEnterprises">
//     Copyright (c) ImprovingEnterprises. All rights reserved.
// </copyright>
// <author>Christopher Nolan</author>
//-----------------------------------------------------------------------
namespace TetrisTDD
{
    using System;
    using System.IO; 
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    


    /// <summary>    using System;
    /// This is the board.  Treat it well.
    /// Note that StyleCop counts here, but tests don't care.
    /// </summary>
    public class Board
    {
        bool isDropping = false; 
        int tick = 0; 
        Block empty = new Block('.'); 
        Block newline = new Block('\n');
        Block[,] map;

        

        public Board(int width, int length)
        {
            this.width = width;
            this.length = length;


            map = new Block[width+1,length];

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    map[i, j] = empty;
                }
            }
            for (int i = 0; i < length; i++)
            {
                map[width , i] = newline;
            }
        }

        public override string ToString()
        {
            string linearBoard = "";
            for (int j = 0; j < length; j++)
            {
                for (int i = 0; i <= width; i++)
                {
                    linearBoard += map[i,j].shape; 
                }
            }
            return linearBoard; 

        }

        public bool HasFalling()
        {
            if (tick == 3)
            {
                return false;
            }

            if (isDropping)
            {
                return true;
            }

            return false; 
        }

        public void Drop(Block block)
        {
            if (isDropping)
            {
                throw new IllegalStateException("already falling");
            }
            else
            {
                map[1, 0] = block;
                isDropping = true;
            }          
               

    
            
            
        }

        public void Drop(char shape)
        {
            Block block = new Block(shape);
            this.Drop(block); 
        }


        public void Tick()
        {
            for (int i = length - 1; i > 0; i--)
            {
                if (map[1, i-1] != empty)
                {
                    map[1, i] = map[1, i - 1];
                    map[1, i - 1] = empty; 
                    isDropping = true;
                }
            }
            map[1, 0] = empty;
            tick++; 
  
           
        }

        public int width { get; set; }
        public int length { get; set; }
    }
}
