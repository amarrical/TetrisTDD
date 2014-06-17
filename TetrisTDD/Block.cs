//-----------------------------------------------------------------------
// <copyright file="FILENAME.cs" company="ImprovingEnterprises">
//     Copyright (c) ImprovingEnterprises. All rights reserved.
// </copyright>
// <author>Christopher Nolan</author>
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisTDD
{
    public class Block
    {
        public Block(char shape)
        {
            this.shape = shape; 
        }

        public char shape { get; set; }
    }
}
