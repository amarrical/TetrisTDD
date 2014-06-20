//-----------------------------------------------------------------------
// <copyright file="FallingPieceRotationLimitations.cs" company="ImprovingEnterprises">
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
    public class FallingPieceRotationLimitations
    {
        private Board board = new Board(6, 6);
        
        [Test]
        public void FallingPieceCanNotRotateWithoutRoom()
        {
            this.board.Drop(new Tetromino(TetrominoShape.O_SHAPE));
            this.board.MovePiece(Direction.Left, Direction.Left, Direction.Left);
            this.board.Ticks(5);
            Assert.IsFalse(this.board.HasFalling());

            this.board.Drop(new Tetromino(TetrominoShape.O_SHAPE));
            this.board.MovePiece(Direction.Left, Direction.Left, Direction.Left);
            this.board.Ticks(3);
            Assert.IsFalse(this.board.HasFalling());

            this.board.Drop(new Tetromino(TetrominoShape.O_SHAPE));
            this.board.MovePiece(Direction.Right);
            this.board.Ticks(5);
            Assert.IsFalse(this.board.HasFalling());

            this.board.Drop(new Tetromino(TetrominoShape.O_SHAPE));
            this.board.MovePiece(Direction.Right);
            this.board.Ticks(3);
            Assert.IsFalse(this.board.HasFalling());

            this.board.Drop(new Tetromino(TetrominoShape.T_SHAPE));
            
            Assert.AreEqual(
                "...T..\n" +
                "..TTT.\n" +
                "OO..OO\n" +
                "OO..OO\n" + 
                "OO..OO\n" +
                "OO..OO\n",
                this.board.ToString());
            Assert.IsTrue(this.board.HasFalling());

            this.board.Rotate(Rotation.Counterclockwise);
            this.board.Ticks(2);
            Assert.AreEqual(
                "......\n" +
                "......\n" +
                "OO.TOO\n" +
                "OOTTOO\n" +
                "OO.TOO\n" +
                "OO..OO\n",
                this.board.ToString());
            Assert.IsTrue(this.board.HasFalling());
            this.board.Rotate(Rotation.Counterclockwise);
            this.board.Rotate(Rotation.Clockwise);
            Assert.AreEqual(
                "......\n" +
                "......\n" +
                "OO.TOO\n" +
                "OOTTOO\n" +
                "OO.TOO\n" +
                "OO..OO\n",
                this.board.ToString());
            Assert.IsTrue(this.board.HasFalling());
        }
    }
}
