//-----------------------------------------------------------------------
// <copyright file="MovingAFallingPiece.cs" company="ImprovingEnterprises">
//     Copyright (c) ImprovingEnterprises. All rights reserved.
// </copyright>
// <author>Patrick Sheehan</author>
//-----------------------------------------------------------------------
namespace TetrisTDD.Test.Step5
{
    using System.Diagnostics.CodeAnalysis;

    using NUnit.Framework;

    [SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules",
        "SA1600:ElementsMustBeDocumented",
        Justification = "Tests are self documenting")]
    [TestFixture]
    public class MovingAFallingPiece
    {
        #region [ Fields ]

        private Board board = new Board(6, 8);

        #endregion

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

        #region [ Tests ]

        [Test]
        public void FallingPieceCanBeMovedLeft()
        {
            this.board.MovePiece(MoveDirection.Left);
            this.board.MovePiece(MoveDirection.Left);
            Assert.AreEqual(
                "..T.....\n" +
                ".TTT....\n" +
                "........\n" +
                "........\n" +
                "........\n" +
                "........\n",
                this.board.ToString());
            this.board.Tick();
            Assert.AreEqual(
                "........\n" +
                "..T.....\n" +
                ".TTT....\n" +
                "........\n" +
                "........\n" +
                "........\n",
                this.board.ToString());
            Assert.IsTrue(this.board.HasFalling());
        }
        
        [Test]
        public void FallingPieceCanBeMovedRight()
        {
            this.board.MovePiece(MoveDirection.Right);
            this.board.MovePiece(MoveDirection.Right);
            Assert.AreEqual(
                "......T.\n" +
                ".....TTT\n" +
                "........\n" +
                "........\n" +
                "........\n" +
                "........\n",
                this.board.ToString());
            this.board.Tick();
            Assert.AreEqual(
                "........\n" +
                "......T.\n" +
                ".....TTT\n" +
                "........\n" +
                "........\n" +
                "........\n",
                this.board.ToString());
            Assert.IsTrue(this.board.HasFalling());
        }

        [Test]
        public void FallingPieceCanBeMovedDown()
        {
            this.board.MovePiece(MoveDirection.Down);
            this.board.MovePiece(MoveDirection.Down);
            Assert.AreEqual(
                "........\n" +
                "........\n" +
                "....T...\n" +
                "...TTT..\n" +
                "........\n" +
                "........\n",
                this.board.ToString());
            this.board.Tick();
            Assert.AreEqual(
                "........\n" +
                "........\n" +
                "........\n" +
                "....T...\n" +
                "...TTT..\n" +
                "........\n",
                this.board.ToString());
            Assert.IsTrue(this.board.HasFalling());
        }

        // TODO: it will not move left over over the board
        // TODO: it will not move right over over the board
        // TODO: it will not move down over over the board (will stop falling)
        // TODO: it can not be moved left if another piece is in the way
        // TODO: it can not be moved right if another piece is in the way
        // TODO: it can not be moved down if another piece is in the way (will stop falling)
        #endregion
    }
}
