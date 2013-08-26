// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FakeVertexRuleRepository.cs" company="Reimers.dk">
//   Copyright � Reimers.dk 2012
//   This source is subject to the Microsoft Public License (Ms-PL).
//   Please see http://go.microsoft.com/fwlink/?LinkID=131993 for details.
//   All other rights reserved.
// </copyright>
// <summary>
//   Defines the FakeVertexRuleRepository type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ArchiMetrics.UI.DataAccess
{
	using System;
	using System.Collections.Generic;
	using System.Xml.Serialization;
	using ArchiMetrics.Common;
	using ArchiMetrics.Common.Structure;

	public class FakeVertexRuleRepository : FakeRepositoryBase, IVertexRuleRepository
	{
		public FakeVertexRuleRepository()
		{
			var rules = new List<VertexRule>(LoadAllVertexRules());
			VertexRules = rules;
		}

		public IList<VertexRule> VertexRules { get; private set; }

		public IEnumerable<Func<string, string>> GetAllVertexPreTransforms()
		{
			return new List<Func<string, string>>();
		}

		public IEnumerable<Func<string, string>> GetAllVertexPostTransforms()
		{
			return new List<Func<string, string>>();
		}

		private IEnumerable<VertexRule> LoadAllVertexRules()
		{
			// In a real application, the data would come from an external source,
			// but for this demo let's keep things simple and use a resource file.
			var serializer = new XmlSerializer(typeof(List<VertexRule>));

			using (var stream = GetResourceStream("vertexrules.xml"))
			{
				return (List<VertexRule>)serializer.Deserialize(stream);
			}
		}
	}
}