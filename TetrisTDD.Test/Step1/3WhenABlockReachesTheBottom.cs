//-----------------------------------------------------------------------
// <copyright file="_3WhenABlockReachesTheBottom.cs" company="ImprovingEnterprises">
//     Copyright (c) ImprovingEnterprises. All rights reserved.
// </copyright>
// <author>Christopher Nolan</author>
//-----------------------------------------------------------------------
namespace TetrisTDD.Test.Step1
{
    using System.Diagnostics.CodeAnalysis;

    using NUnit.Framework;

    [SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules",
        "SA1600:ElementsMustBeDocumented",
        Justification = "Tests are self documenting")]
    [TestFixture]
    public class _3WhenABlockReachesTheBottom : _0FallingBlockTests
    {
        [SetUp]
        public void FallToLastRow()
        {
            this.board.Drop(new Block('X'));
            this.board.Tick();
            this.board.Tick();
        }

        #region [ Tests ]

        [Test]
        public void ItIsStillFallingOnTheLastRow()
        {
            Assert.IsTrue(this.board.HasFalling());
            Assert.AreEqual("...\n...\n.X.\n", this.board.ToString());
        }

        [Test]
        public void BlockStopsWhenItHitsTheBottom()
        {
            this.board.Tick();
            Assert.IsFalse(this.board.HasFalling());
            Assert.AreEqual("...\n...\n.X.\n", this.board.ToString());
        }

        #endregion
    }
}
