//-----------------------------------------------------------------------
// <copyright file="_2TheIShape.cs" company="ImprovingEnterprises">
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
    public class _2TheIShape : _0RotatingTetrominoes
    {
        [SetUp]
        public void CreateIShape()
        {
            this.shape = new Tetromino(TetrominoShape.I_SHAPE);
        }

        #region [ Tests ]

        [Test]
        public void IsShapedLikeI()
        {
            Assert.AreEqual(
                    ".....\n" +
                    ".....\n" +
                    "IIII.\n" +
                    ".....\n" +
                    ".....\n", 
                    shape.ToString());
        }

        [Test]
        public void CanBeRotatedRightOnce()
        {
            this.shape = this.shape.RotateRight();
            Assert.AreEqual(
                    "..I..\n" +
                    "..I..\n" +
                    "..I..\n" +
                    "..I..\n" +
                    ".....\n",
                    this.shape.ToString());
        }

        [Test]
        public void CanBeRotatedLeftOnce()
        {
            this.shape = this.shape.RotateLeft();
            Assert.AreEqual(
                    "..I..\n" +
                    "..I..\n" +
                    "..I..\n" +
                    "..I..\n" +
                    ".....\n",
                    this.shape.ToString());
        }

        [Test]
        public void RotatingItTwiceWillGoBackToTheOriginalShape()
        {
            string original = this.shape.ToString();
            this.shape = this.shape.RotateRight().RotateRight();
            Assert.AreEqual(original, this.shape.ToString());
            this.shape = this.shape.RotateLeft().RotateLeft();
            Assert.AreEqual(original, this.shape.ToString());
        }
        #endregion
    }
}
