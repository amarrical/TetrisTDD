//-----------------------------------------------------------------------
// <copyright file="0FallingPieces.cs" company="ImprovingEnterprises">
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
    [SetUpFixture]
    public class _0FallingPieces
    {
        #region [ Fields ]

        protected Board board = new Board(6, 8);

        #endregion
    }
}
