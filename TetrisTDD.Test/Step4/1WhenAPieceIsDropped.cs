//-----------------------------------------------------------------------
// <copyright file="WhenAPieceIsDroppped.cs" company="ImprovingEnterprises">
//     Copyright (c) ImprovingEnterprises. All rights reserved.
// </copyright>
// <author>Patrick Sheehan</author>
//-----------------------------------------------------------------------
namespace TetrisTDD.Test.Step4
{
    using System.Diagnostics.CodeAnalysis;

    using NUnit.Framework;

    using TetrisTDD.Entities;
    using TetrisTDD.Enums;

    [SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules",
        "SA1600:ElementsMustBeDocumented",
        Justification = "Tests are self documenting")]
    [TestFixture]
    public class _1WhenAPieceIsDropped : _0FallingPieces
    {
        [SetUp]
        public void DropPiece()
        {
            this.board.Drop(new Tetromino(TetrominoShape.T_SHAPE));
        }

        [Test]
        public void ItStartsFromTopMiddle()
        {
            Assert.AreEqual(
                "....T...\n" +
                "...TTT..\n" +
                "........\n" +
                "........\n" +
                "........\n" +
                "........\n",
                this.board.ToString());
        }
    }
}
