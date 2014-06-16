//-----------------------------------------------------------------------
// <copyright file="_1TheTShape.cs" company="ImprovingEnterprises">
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
    public class _1TheTShape : _0RotatingTetrominoes
    {
        [SetUp]
        public void CreateTShape()
        {
            shape = new Tetromino(TetrominoShape.T_SHAPE);
        }

        #region [ Tests ]

        [Test]
        public void IsShapedLikeT()
        {
            Assert.AreEqual(
                    ".T.\n" +
                    "TTT\n" +
                    "...\n", shape.ToString());
        }

        [Test]
        public void CanBeRotatedRight3Times()
        {
            shape = shape.RotateRight();
            Assert.AreEqual(
                    ".T.\n" +
                    ".TT\n" +
                    ".T.\n",
                    shape.ToString());
            shape = shape.RotateRight();
            Assert.AreEqual(
                    "...\n" +
                    "TTT\n" +
                    ".T.\n",
                    shape.ToString());
            shape = shape.RotateRight();
            Assert.AreEqual(
                    ".T.\n" +
                    "TT.\n" +
                    ".T.\n",
                    shape.ToString());
        }

        [Test]
        public void CanBeRotatedLeft3Times()
        {
            shape = shape.RotateLeft();
            Assert.AreEqual(
                    ".T.\n" +
                    "TT.\n" +
                    ".T.\n",
                    shape.ToString());
            shape = shape.RotateLeft();
            Assert.AreEqual(
                    "...\n" +
                    "TTT\n" +
                    ".T.\n",
                    shape.ToString());
            shape = shape.RotateLeft();
            Assert.AreEqual(
                    ".T.\n" +
                    ".TT\n" +
                    ".T.\n",
                    shape.ToString());
        }

        #endregion
    }
}
