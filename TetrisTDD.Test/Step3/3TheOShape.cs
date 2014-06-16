//-----------------------------------------------------------------------
// <copyright file="_3TheOShape.cs" company="ImprovingEnterprises">
//     Copyright (c) ImprovingEnterprises. All rights reserved.
// </copyright>
// <author>Patrick Sheehan</author>
//-----------------------------------------------------------------------
namespace TetrisTDD.Test.Step3
{
    using System.Diagnostics.CodeAnalysis;

    using NUnit.Framework;

    [SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules",
        "SA1600:ElementsMustBeDocumented",
        Justification = "Tests are self documenting")]
    [TestFixture]
    public class _3TheOShape : _0RotatingTetrominoes
    {
        [SetUp]
        public void CreateOShape()
        {
            this.shape = new Tetromino(TetrominoShape.O_SHAPE);
        }

        #region [ Tests ]

        [Test]
        public void IsShapedLikeO()
        {
            Assert.AreEqual(
                    ".OO\n" +
                    ".OO\n" +
                    "...\n",
                    this.shape.ToString());
        }

        [Test]
        public void CanNotBeRotatedRight()
        {
            this.shape = this.shape.RotateRight();
            Assert.AreEqual(
                    ".OO\n" +
                    ".OO\n" +
                    "...\n",
                    this.shape.ToString());
        }

        [Test]
        public void CanNotBeRotatedLeft()
        {
            this.shape = this.shape.RotateLeft();
            Assert.AreEqual(
                    ".OO\n" +
                    ".OO\n" +
                    "...\n",
                    this.shape.ToString());
        }

        #endregion
    }
}
