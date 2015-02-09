﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MemberDocumentationFactoryTests.cs" company="Reimers.dk">
//   Copyright © Reimers.dk 2014
//   This source is subject to the Microsoft Public License (Ms-PL).
//   Please see http://go.microsoft.com/fwlink/?LinkID=131993 for details.
//   All other rights reserved.
// </copyright>
// <summary>
//   Defines the MemberDocumentationFactoryTests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ArchiMetrics.Analysis.Tests.Metrics
{
	using System.Linq;
	using System.Threading;
	using System.Threading.Tasks;
	using ArchiMetrics.Analysis.Metrics;
	using Microsoft.CodeAnalysis;
	using Microsoft.CodeAnalysis.CSharp;
	using NUnit.Framework;

	public class MemberDocumentationFactoryTests
	{
		private MemberDocumentationFactoryTests()
		{
		}

		[TestFixture]
		public class GivenAMemberDocumentationFactory : SolutionTestsBase
		{
			private MemberDocumentationFactory _sut;

			[SetUp]
			public void Setup()
			{
				_sut = new MemberDocumentationFactory();
			}

			[TestCase(@"public string GetValue() { return ""a""; }", "Method summary", SyntaxKind.MethodDeclaration)]
			[TestCase(@"public string Value { get { return ""a""; } }", "Property summary", SyntaxKind.GetAccessorDeclaration)]
			[TestCase(@"public string Value { set { /*/Do nothing*/ } }", "Property summary", SyntaxKind.SetAccessorDeclaration)]
			public async Task WhenGettingDocumentationForPropertyThenReadsFromPropertyDefinition(string code, string summary, SyntaxKind kind)
			{
				var codeFile = string.Format(
@"namespace TestNs
{{
	public class DocClass
	{{
		/// <summary>{0}</summary>
		{1}
	}}
}}",
  summary,
  code);

				var solution = CreateSolution(codeFile);
				var project = solution.Projects.First();
				var document = project.Documents.First();
				var model = await document.GetSemanticModelAsync();
				var docRoot = await document.GetSyntaxRootAsync();
				var node = docRoot.DescendantNodes().First(x => x.Kind() == kind);
				var symbol = model.GetDeclaredSymbol(node);
				var documentation = await _sut.Create(symbol, CancellationToken.None);

				Assert.AreEqual(summary, documentation.Summary);
			}
		}
	}
}