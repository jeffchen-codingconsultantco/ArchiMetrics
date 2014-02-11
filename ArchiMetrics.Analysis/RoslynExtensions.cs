// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RoslynExtensions.cs" company="Reimers.dk">
//   Copyright � Reimers.dk 2013
//   This source is subject to the Microsoft Public License (Ms-PL).
//   Please see http://go.microsoft.com/fwlink/?LinkID=131993 for details.
//   All other rights reserved.
// </copyright>
// <summary>
//   Defines the RoslynExtensions type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ArchiMetrics.Analysis
{
	using Roslyn.Compilers.Common;
	using Roslyn.Compilers.CSharp;

	public static class RoslynExtensions
	{
		public static MethodDeclarationSyntax GetMethod(this CommonSyntaxToken token)
		{
			return GetMethod((SyntaxToken)token);
		}

		public static MethodDeclarationSyntax GetMethod(this SyntaxToken token)
		{
			var parent = token.Parent;
			return GetMethod(parent);
		}

		public static MethodDeclarationSyntax GetMethod(this SyntaxNode node)
		{
			if (node == null)
			{
				return null;
			}

			if (node.Kind == SyntaxKind.MethodDeclaration)
			{
				return (MethodDeclarationSyntax)node;
			}

			return GetMethod(node.Parent);
		}
	}
}