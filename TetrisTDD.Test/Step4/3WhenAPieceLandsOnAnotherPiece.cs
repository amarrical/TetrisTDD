//-----------------------------------------------------------------------
// <copyright file="3WhenAPieceLandsOnAnotherPiece.cs" company="ImprovingEnterprises">
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
    public class _4WhenAPieceLandsOnAnotherPiece : _0FallingPieces
    {
        [SetUp]
        public void LandOnAnother()
        {
            this.board.ClearBoard();
            this.board.Drop(new Tetromino(TetrominoShape.T_SHAPE));
            this.board.Ticks(5);
            Assert.AreEqual(
                   "........\n" +
                   "........\n" +
                   "........\n" +
                   "........\n" +
                   "....T...\n" +
                   "...TTT..\n",
                   this.board.ToString());
            Assert.IsFalse(this.board.HasFalling());

            this.board.Drop(new Tetromino(TetrominoShape.T_SHAPE));
            this.board.Ticks(2);
        }

        [Test]
        public void ItIsStillFallingRightAboveTheOtherPiece()
        {
            Assert.AreEqual(
                   "........\n" +
                   "........\n" +
                   "....T...\n" +
                   "...TTT..\n" +
                   "....T...\n" +
                   "...TTT..\n",
                   this.board.ToString());
            Assert.IsTrue(this.board.HasFalling());
        }

        [Test]
        public void ItStopsWhenItHitsTheOtherPiece()
        {
            this.board.Tick();
            Assert.AreEqual(
                   "........\n" +
                   "........\n" +
                   "....T...\n" +
                   "...TTT..\n" +
                   "....T...\n" +
                   "...TTT..\n",
                   this.board.ToString());
            Assert.IsFalse(this.board.HasFalling());
        }
    }
}
