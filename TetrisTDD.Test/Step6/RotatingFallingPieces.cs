//-----------------------------------------------------------------------
// <copyright file="RotatingFallingPieces.cs" company="ImprovingEnterprises">
//     Copyright (c) ImprovingEnterprises. All rights reserved.
// </copyright>
// <author>Patrick Sheehan</author>
//-----------------------------------------------------------------------
namespace TetrisTDD.Test.Step6
{
    using System.Diagnostics.CodeAnalysis;

    using NUnit.Framework;

    [SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules",
        "SA1600:ElementsMustBeDocumented",
        Justification = "Tests are self documenting")]
    [TestFixture]
    public class RotatingFallingPieces
    {
        private Board board = new Board(6, 8);

        [SetUp]
        public void DropAPiece()
        {
            this.board.ClearBoard();
            this.board.Drop(new Tetromino(TetrominoShape.T_SHAPE));
            Assert.AreEqual(
                "....T...\n" +
                "...TTT..\n" +
                "........\n" +
                "........\n" +
                "........\n" +
                "........\n",
                this.board.ToString());
        }

        [Test]
        public void FallingPieceCanRotateClockwise()
        {
            this.board.Tick();
            this.board.Rotate(RotationDirection.Right);
            Assert.AreEqual(
                "........\n" +
                "....T...\n" +
                "....TT..\n" +
                "....T...\n" +
                "........\n" +
                "........\n",
                this.board.ToString());
            Assert.IsTrue(this.board.HasFalling());
            this.board.Tick();
            Assert.AreEqual(
                "........\n" +
                "........\n" +
                "....T...\n" +
                "....TT..\n" +
                "....T...\n" +
                "........\n",
                this.board.ToString());
            Assert.IsTrue(this.board.HasFalling());
        }

        [Test]
        public void FallingPieceCanRotateCounterClockwise()
        {
            this.board.Tick();
            this.board.Rotate(RotationDirection.Left);
            Assert.AreEqual(
                "........\n" +
                "....T...\n" +
                "...TT...\n" +
                "....T...\n" +
                "........\n" +
                "........\n",
                this.board.ToString());
            Assert.IsTrue(this.board.HasFalling());
            this.board.Tick();
            Assert.AreEqual(
                "........\n" +
                "........\n" +
                "....T...\n" +
                "...TT...\n" +
                "....T...\n" +
                "........\n",
                this.board.ToString());
            Assert.IsTrue(this.board.HasFalling());
        }
    }
}
