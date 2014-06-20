//-----------------------------------------------------------------------
// <copyright file="_2Rotate5x5Piece.cs" company="ImprovingEnterprises">
//     Copyright (c) ImprovingEnterprises. All rights reserved.
// </copyright>
// <author>Anthony Marrical</author>
//-----------------------------------------------------------------------
namespace TetrisTDD.Test.Step2
{
    using System.Diagnostics.CodeAnalysis;

    using NUnit.Framework;

    using TetrisTDD.Entities;
    using TetrisTDD.Enums;

    [SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules",
        "SA1600:ElementsMustBeDocumented",
        Justification = "Tests are self documenting")]
    [TestFixture]
    public class _2Rotate5x5Piece : _0RotatingPiecesOfBlocks
    {
        [SetUp]
        public void CreateAPiece()
        {
            this.piece = new Piece(
                "..XXX\n" +
                "..XX.\n" +
                "..X..\n" +
                ".....\n" +
                ".....\n");
        }

        #region [ Tests ]

        [Test]
        public void PieceConsistsOfManyBlocks()
        {
            Assert.AreEqual(
                "..XXX\n" +
                "..XX.\n" +
                "..X..\n" +
                ".....\n" +
                ".....\n",
                this.piece.ToString());
        }

        [Test]
        public void CanBeRotatedRight()
        {
            this.piece.Rotate(Rotation.Clockwise);
            Assert.AreEqual(
                ".....\n" +
                ".....\n" +
                "..XXX\n" +
                "...XX\n" +
                "....X\n",
                this.piece.ToString());
        }

        [Test]
        public void CanBeRotatedLeft()
        {
            this.piece.Rotate(Rotation.Counterclockwise);
            Assert.AreEqual(
                "X....\n" +
                "XX...\n" +
                "XXX..\n" +
                ".....\n" +
                ".....\n",
                this.piece.ToString());
        }

        #endregion
    }
}
