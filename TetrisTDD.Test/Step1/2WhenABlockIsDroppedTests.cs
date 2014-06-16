﻿//-----------------------------------------------------------------------
// <copyright file="_2WhenABlockIsDroppedTests.cs" company="ImprovingEnterprises">
//     Copyright (c) ImprovingEnterprises. All rights reserved.
// </copyright>
// <author>Christopher Nolan</author>
//-----------------------------------------------------------------------
namespace TetrisTDD.Test.Step1
{
    using System.Diagnostics.CodeAnalysis;

    using NUnit.Framework;
    using System;

    [SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules",
        "SA1600:ElementsMustBeDocumented",
        Justification = "Tests are self documenting")]
    [TestFixture]
    public class _2WhenABlockIsDroppedTests : _0FallingBlockTests
    {
        [SetUp]
        public void DropABlock()
        {
            this.board.Drop(new Block('X'));
        }

        #region [ Tests ]

        [Test]
        public void TheBlockIsFalling()
        {
            Assert.IsTrue(this.board.HasFalling());
        }

        [Test]
        public void ItStartsFromTopMiddle()
        {
            Assert.AreEqual(".X.\n...\n...\n", board.ToString());
        }

        [Test]
        public void ItMovesDownOneRowPerTick()
        {
            board.Tick(); 
            Assert.AreEqual("...\n.X.\n...\n", this.board.ToString());
        }

        [Test]
        public void AtMostOneBlockMayBeFallingAtATime()
        {
            try
            {
                board.Drop(new Block('Y'));
            }

            catch (IllegalStateException e)
            {
                Assert.IsTrue(e.Message.Contains(e.Message));
            }
            
            Assert.AreEqual(".X.\n...\n...\n", board.ToString());
        }

        #endregion
    }
}
