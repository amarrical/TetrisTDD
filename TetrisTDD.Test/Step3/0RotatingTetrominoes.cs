//-----------------------------------------------------------------------
// <copyright file="_0RotatingTetrominoes.cs" company="ImprovingEnterprises">
//     Copyright (c) ImprovingEnterprises. All rights reserved.
// </copyright>
// <author>Patrick Sheehan</author>
//-----------------------------------------------------------------------
namespace TetrisTDD.Test.Step3
{
    using System.Diagnostics.CodeAnalysis;

    using NUnit.Framework;

    [SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules",
        "SA1600:ElementsMustBeDocumented",
        Justification = "Tests are self documenting")]
    [TestFixture]
    public class _0RotatingTetrominoes
    {
        #region [ Fields ]

        protected Tetromino shape;

        #endregion

        [SetUp]
        public void CreateAnyShape()
        {
            this.shape = new Tetromino(TetrominoShape.T_SHAPE);
        }

        #region [ Tests ]

        [Test]
        public void AreImmutable()
        {
            string original = this.shape.ToString();

            this.shape.Rotate(RotationDirection.Right);
            Assert.AreEqual(original, this.shape.ToString());

            this.shape.Rotate(RotationDirection.Left);
            Assert.AreEqual(original, this.shape.ToString());
        }
        #endregion
    }
}