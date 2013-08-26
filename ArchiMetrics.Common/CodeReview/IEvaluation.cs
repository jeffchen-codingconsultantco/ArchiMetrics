// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IEvaluation.cs" company="Reimers.dk">
//   Copyright � Reimers.dk 2012
//   This source is subject to the Microsoft Public License (Ms-PL).
//   Please see http://go.microsoft.com/fwlink/?LinkID=131993 for details.
//   All other rights reserved.
// </copyright>
// <summary>
//   Defines the IEvaluation type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ArchiMetrics.Common.CodeReview
{
	using Roslyn.Compilers.CSharp;

	public interface IEvaluation
	{
		SyntaxKind EvaluatedKind { get; }

		string Title { get; }

		string Suggestion { get; }
	}
}