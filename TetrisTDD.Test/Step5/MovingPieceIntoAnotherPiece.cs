//-----------------------------------------------------------------------
// <copyright file="MovingPieceIntoAnotherPiece.cs" company="ImprovingEnterprises">
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
    public class MovingPieceIntoAnotherPiece
    {
        private Board board = new Board(6, 8);

        [SetUp]
        public void DropPieces()
        {
            this.board.ClearBoard();
            this.board.Drop(new Tetromino(TetrominoShape.T_SHAPE));
            this.board.MovePiece(Direction.Left, Direction.Left, Direction.Left);
            this.board.Ticks(5);

            this.board.Drop(new Tetromino(TetrominoShape.T_SHAPE));
            this.board.MovePiece(Direction.Right, Direction.Right);

            this.board.Ticks(5);

            Assert.AreEqual(
                "........\n" +
                "........\n" +
                "........\n" +
                "........\n" +
                ".T....T.\n" +
                "TTT..TTT\n",
                this.board.ToString());
        }

        #region [ Tests ]

        [Test]
        public void CanNotBeMovedLeftIntoAnotherPiece()
        {
            this.board.Drop(new Tetromino(TetrominoShape.T_SHAPE));
            this.board.MovePiece(Direction.Left);
            this.board.Ticks(3);

            Assert.AreEqual(
                 "........\n" +
                 "........\n" +
                 "........\n" +
                 "...T....\n" +
                 ".TTTT.T.\n" +
                 "TTT..TTT\n",
                 this.board.ToString());

            this.board.MovePiece(Direction.Left);
            Assert.AreEqual(
                 "........\n" +
                 "........\n" +
                 "........\n" +
                 "...T....\n" +
                 ".TTTT.T.\n" +
                 "TTT..TTT\n",
                 this.board.ToString());
        }

        [Test]
        public void CanNotBeMovedRightIntoAnotherPiece()
        {
            this.board.Drop(new Tetromino(TetrominoShape.T_SHAPE));
            this.board.Ticks(3);

            Assert.AreEqual(
                 "........\n" +
                 "........\n" +
                 "........\n" +
                 "....T...\n" +
                 ".T.TTTT.\n" +
                 "TTT..TTT\n",
                 this.board.ToString());

            this.board.MovePiece(Direction.Right);
            Assert.AreEqual(
                 "........\n" +
                 "........\n" +
                 "........\n" +
                 "....T...\n" +
                 ".T.TTTT.\n" +
                 "TTT..TTT\n",
                 this.board.ToString());
        }

        [Test]
        public void CanNotBeMovedDownIntoAnotherPiece()
        {
            this.board.Drop(new Tetromino(TetrominoShape.T_SHAPE));
            this.board.Ticks(3);

            Assert.AreEqual(
                 "........\n" +
                 "........\n" +
                 "........\n" +
                 "....T...\n" +
                 ".T.TTTT.\n" +
                 "TTT..TTT\n",
                 this.board.ToString());

            this.board.MovePiece(Direction.Down);
            Assert.AreEqual(
                 "........\n" +
                 "........\n" +
                 "........\n" +
                 "....T...\n" +
                 ".T.TTTT.\n" +
                 "TTT..TTT\n",
                 this.board.ToString());

            Assert.IsFalse(this.board.HasFalling());
        }

        #endregion
    }
}
