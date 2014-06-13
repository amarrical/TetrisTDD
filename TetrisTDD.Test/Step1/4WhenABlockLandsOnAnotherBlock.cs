//-----------------------------------------------------------------------
// <copyright file="_4WhenABlockLandsOnAnotherBlock.cs" company="ImprovingEnterprises">
//     Copyright (c) ImprovingEnterprises. All rights reserved.
// </copyright>
// <author>Anthony Marrical</author>
//-----------------------------------------------------------------------
namespace TetrisTDD.Test.Step1
{
    using System.Diagnostics.CodeAnalysis;

    using NUnit.Framework;

    [SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules",
        "SA1600:ElementsMustBeDocumented",
        Justification = "Tests are self documenting")]
    [TestFixture]
    public class _4WhenABlockLandsOnAnotherBlock : _0FallingBlockTests
    {
        [SetUp]
        public void LandOnAnotherBlock()
        {
            this.board.Drop('X');
            board.Tick();
            board.Tick();
            board.Tick();
            Assert.AreEqual("...\n...\n.X.\n", this.board.ToString());
            Assert.IsFalse(board.HasFalling());

            this.board.Drop('Y');
            board.Tick();
        }

        #region [ Tests ]

        [Test]
        public void BoardStillHasFallingRightAboveOtherBlock()
        {
            Assert.IsTrue(this.board.HasFalling());
            Assert.AreEqual("...\n.Y.\n.X.\n", this.board.ToString());
        }

        [Test]
        public void BlockStopsWhenItHitsTheOtherBlock()
        {
            this.board.Tick();
            Assert.IsFalse(this.board.HasFalling());
            Assert.AreEqual("...\n.Y.\n.X.\n", this.board.ToString());
        }

        #endregion
    }
}
