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

    using TetrisTDD.Entities;
    using TetrisTDD.Enums;

    [SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules",
        "SA1600:ElementsMustBeDocumented",
        Justification = "Tests are self documenting")]
    [TestFixture]
    public class _1TheTShape : _0RotatingTetrominoes
    {
        [SetUp]
        public void CreateTShape()
        {
            this.shape = new Tetromino(TetrominoShape.T_SHAPE);
        }

        #region [ Tests ]

        [Test]
        public void IsShapedLikeT()
        {
            Assert.AreEqual(
                    ".T.\n" +
                    "TTT\n" +
                    "...\n",
                    this.shape.ToString());
        }

        [Test]
        public void CanBeRotatedRight3Times()
        {
            this.shape = this.shape.Rotate(Rotation.Clockwise);
            Assert.AreEqual(
                    ".T.\n" +
                    ".TT\n" +
                    ".T.\n",
                    shape.ToString());
            this.shape = this.shape.Rotate(Rotation.Clockwise);
            Assert.AreEqual(
                    "...\n" +
                    "TTT\n" +
                    ".T.\n",
                    this.shape.ToString());
            this.shape = this.shape.Rotate(Rotation.Clockwise);
            Assert.AreEqual(
                    ".T.\n" +
                    "TT.\n" +
                    ".T.\n",
                    this.shape.ToString());
        }

        [Test]
        public void CanBeRotatedLeft3Times()
        {
            this.shape = this.shape.Rotate(Rotation.Counterclockwise);
            Assert.AreEqual(
                    ".T.\n" +
                    "TT.\n" +
                    ".T.\n",
                    this.shape.ToString());
            this.shape = this.shape.Rotate(Rotation.Counterclockwise);
            Assert.AreEqual(
                    "...\n" +
                    "TTT\n" +
                    ".T.\n",
                    this.shape.ToString());
            this.shape = this.shape.Rotate(Rotation.Counterclockwise);
            Assert.AreEqual(
                    ".T.\n" +
                    ".TT\n" +
                    ".T.\n",
                    this.shape.ToString());
        }

        [Test]
        public void RotatingIt4TimesWillGoBackToTheOriginalShape()
        {
            string original = this.shape.ToString();
            this.shape = this.shape.Rotate(Rotation.Clockwise, Rotation.Clockwise, Rotation.Clockwise, Rotation.Clockwise);
            Assert.AreEqual(original, shape.ToString());
            this.shape = this.shape.Rotate(Rotation.Counterclockwise, Rotation.Counterclockwise, Rotation.Counterclockwise, Rotation.Counterclockwise);
            Assert.AreEqual(original, this.shape.ToString());
        }

        #endregion
    }
}
