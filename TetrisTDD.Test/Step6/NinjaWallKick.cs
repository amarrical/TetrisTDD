//-----------------------------------------------------------------------
// <copyright file="NinjaWallKick.cs" company="ImprovingEnterprises">
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
    public class NinjaWallKick
    {
        private Board board = new Board(6, 8);

        [SetUp]
        public void PlaceBlockByWall()
        {
            this.board.Drop(new Tetromino(TetrominoShape.T_SHAPE));
            this.board.Rotate(RotationDirection.Right);
            this.board.MovePiece(MoveDirection.Left);
            this.board.MovePiece(MoveDirection.Left);
            this.board.MovePiece(MoveDirection.Left);
            this.board.MovePiece(MoveDirection.Left);
            Assert.AreEqual(
                "T.......\n" +
                "TT......\n" +
                "T.......\n" +
                "........\n" +
                "........\n" +
                "........\n",
                this.board.ToString());
        }

        [Test]
        public void FallingPieceRotatedMovesAwayFromWall()
        {
            this.board.Rotate(RotationDirection.Left);

            Assert.AreEqual(
                    ".T......\n" +
                    "TTT.....\n" +
                    "........\n" +
                    "........\n" +
                    "........\n" +
                    "........\n",
                    this.board.ToString());

            this.board.Rotate(RotationDirection.Left);
            this.board.MovePiece(MoveDirection.Right);
            this.board.MovePiece(MoveDirection.Right);
            this.board.MovePiece(MoveDirection.Right);
            this.board.MovePiece(MoveDirection.Right);
            this.board.MovePiece(MoveDirection.Right);
            this.board.MovePiece(MoveDirection.Right);

            Assert.AreEqual(
                    ".......T\n" +
                    "......TT\n" +
                    ".......T\n" +
                    "........\n" +
                    "........\n" +
                    "........\n",
                    this.board.ToString());

            this.board.Rotate(RotationDirection.Right);

            Assert.AreEqual(
                    "......T.\n" +
                    ".....TTT\n" +
                    "........\n" +
                    "........\n" +
                    "........\n" +
                    "........\n",
                    this.board.ToString());
        }
    }
}
