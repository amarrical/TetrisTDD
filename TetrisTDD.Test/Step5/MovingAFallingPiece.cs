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

    using TetrisTDD.Entities;
    using TetrisTDD.Enums;

    [SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules",
        "SA1600:ElementsMustBeDocumented",
        Justification = "Tests are self documenting")]
    [TestFixture]
    public class MovingAFallingPiece
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

        #region [ Tests ]

        [Test]
        public void FallingPieceCanBeMovedLeft()
        {
            this.board.MovePiece(Direction.Left, Direction.Left);
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
            this.board.MovePiece(Direction.Right, Direction.Right);
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
            this.board.MovePiece(Direction.Down, Direction.Down);
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

        [Test]
        public void CanNotMoveLeftPastBorder()
        {
            this.board.MovePiece(Direction.Left, Direction.Left, Direction.Left);
            Assert.AreEqual(
                ".T......\n" +
                "TTT.....\n" +
                "........\n" +
                "........\n" +
                "........\n" +
                "........\n",
                this.board.ToString());
            this.board.MovePiece(Direction.Left);
            Assert.AreEqual(
                ".T......\n" +
                "TTT.....\n" +
                "........\n" +
                "........\n" +
                "........\n" +
                "........\n",
                this.board.ToString());
        }

        [Test]
        public void CanNotMoveRightPastBorder()
        {
            this.board.MovePiece(Direction.Right, Direction.Right, Direction.Right);
            Assert.AreEqual(
                "......T.\n" +
                ".....TTT\n" +
                "........\n" +
                "........\n" +
                "........\n" +
                "........\n",
                this.board.ToString());
            this.board.MovePiece(Direction.Right);
            Assert.AreEqual(
                "......T.\n" +
                ".....TTT\n" +
                "........\n" +
                "........\n" +
                "........\n" +
                "........\n",
                this.board.ToString());
        }

        [Test]
        public void CanNotMoveDownPastBorder()
        {
            this.board.MovePiece(Direction.Down, Direction.Down, Direction.Down, Direction.Down);
            Assert.AreEqual(
                "........\n" +
                "........\n" +
                "........\n" +
                "........\n" +
                "....T...\n" +
                "...TTT..\n",
                this.board.ToString());
            this.board.MovePiece(Direction.Down);
            Assert.AreEqual(
                "........\n" +
                "........\n" +
                "........\n" +
                "........\n" +
                "....T...\n" +
                "...TTT..\n",
                this.board.ToString());
        }

        #endregion
    }
}
