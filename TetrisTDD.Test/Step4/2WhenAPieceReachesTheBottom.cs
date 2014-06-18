//-----------------------------------------------------------------------
// <copyright file="2WhenAPieceReachesTheBottom.cs" company="ImprovingEnterprises">
//     Copyright (c) ImprovingEnterprises. All rights reserved.
// </copyright>
// <author>Patrick Sheehan</author>
//-----------------------------------------------------------------------
namespace TetrisTDD.Test.Step4
{
    using System.Diagnostics.CodeAnalysis;

    using NUnit.Framework;

    [SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules",
        "SA1600:ElementsMustBeDocumented",
        Justification = "Tests are self documenting")]
    [TestFixture]
    public class _2WhenAPieceReachesTheBottom : _0FallingPieces
    {
        [SetUp]
        public void FallToLastRow()
        {
            this.board.Drop(new Tetromino(TetrominoShape.T_SHAPE));
            this.board.Tick();
            this.board.Tick();
            this.board.Tick();
            this.board.Tick();
        }

        [Test]
        public void ItIsStillFallingOnTheLastRow()
        {
            Assert.AreEqual(
                    "........\n" +
                    "........\n" +
                    "........\n" +
                    "........\n" +
                    "....T...\n" +
                    "...TTT..\n",
                    this.board.ToString());
            Assert.IsTrue(this.board.HasFalling());
            this.board.ClearBoard();
        }

        [Test]
        [Ignore]
        public void ItStopsWhenItHitsTheBottom()
        {
            this.board.Tick();
            Assert.AreEqual(
                    "........\n" +
                    "........\n" +
                    "........\n" +
                    "........\n" +
                    "....T...\n" +
                    "...TTT..\n",
                    this.board.ToString());
            Assert.IsFalse(this.board.HasFalling());
            this.board.ClearBoard();
        }
    }
}
