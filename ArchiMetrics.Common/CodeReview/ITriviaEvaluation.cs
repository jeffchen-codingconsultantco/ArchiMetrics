// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ITriviaEvaluation.cs" company="Reimers.dk">
//   Copyright � Reimers.dk 2013
//   This source is subject to the Microsoft Public License (Ms-PL).
//   Please see http://go.microsoft.com/fwlink/?LinkID=131993 for details.
//   All other rights reserved.
// </copyright>
// <summary>
//   Defines the ITriviaEvaluation type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ArchiMetrics.Common.CodeReview
{
	using Roslyn.Compilers.CSharp;

	public interface ITriviaEvaluation : IEvaluation
	{
		EvaluationResult Evaluate(SyntaxTrivia trivia);
	}
}