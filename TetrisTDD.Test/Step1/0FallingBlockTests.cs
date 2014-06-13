//-----------------------------------------------------------------------
// <copyright file="_0FallingBlockTests.cs" company="ImprovingEnterprises">
//     Copyright (c) ImprovingEnterprises. All rights reserved.
// </copyright>
// <author>Anthony Marrical</author>
//-----------------------------------------------------------------------
namespace TetrisTDD.Test.Step1
{
    using System.Diagnostics.CodeAnalysis;

    using NUnit.Framework;

    [SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules",
        "SA1600:ElementsMustBeDocumented",
        Justification = "Tests are self documenting")]
    [SetUpFixture]
    public class _0FallingBlockTests
    {
        #region [ Fields ]

        protected Board board;

        #endregion

        [SetUp]
        public void SetUp()
        {
            this.board = new Board(3, 3);
        }
    }
}
