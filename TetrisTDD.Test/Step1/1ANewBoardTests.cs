//-----------------------------------------------------------------------
// <copyright file="_1ANewBoardTests.cs" company="ImprovingEnterprises">
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
    public class _1ANewBoardTests : _0FallingBlockTests
    {
        #region [ Tests ]

        [Test]
        public void IsEmpty()
        {
            Assert.AreEqual("...\n...\n...\n", this.board.ToString());
        }

        [Test]
        public void HasNoFallingBlocks()
        {
            Assert.IsFalse(this.board.HasFalling());
        }

        #endregion
    }
}
