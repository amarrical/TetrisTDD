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

    using TetrisTDD.Entities;
    using TetrisTDD.Enums;

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
            this.board.Rotate(Rotation.Clockwise);
            this.board.MovePiece(Direction.Left, Direction.Left, Direction.Left, Direction.Left);
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
            this.board.Rotate(Rotation.Counterclockwise);

            Assert.AreEqual(
                    ".T......\n" +
                    "TTT.....\n" +
                    "........\n" +
                    "........\n" +
                    "........\n" +
                    "........\n",
                    this.board.ToString());

            this.board.Rotate(Rotation.Counterclockwise);
            this.board.MovePiece(Direction.Right, Direction.Right, Direction.Right, Direction.Right, Direction.Right, Direction.Right);

            Assert.AreEqual(
                    ".......T\n" +
                    "......TT\n" +
                    ".......T\n" +
                    "........\n" +
                    "........\n" +
                    "........\n",
                    this.board.ToString());

            this.board.Rotate(Rotation.Clockwise);

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
