// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CodeQuality.cs" company="Reimers.dk">
//   Copyright � Reimers.dk 2012
//   This source is subject to the Microsoft Public License (Ms-PL).
//   Please see http://go.microsoft.com/fwlink/?LinkID=131993] for details.
//   All other rights reserved.
// </copyright>
// <summary>
//   Defines the CodeQuality type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace ArchiMetrics.Common
{
	public enum CodeQuality
	{
		Broken = 0, 
		NeedsReEngineering = 1, 
		NeedsRefactoring = 2, 
		Incompetent = 3, 
		NeedsReview = 4, 
		Good = 5
	}
}
