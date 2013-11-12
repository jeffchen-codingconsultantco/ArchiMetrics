// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProjectCodeMetrics.cs" company="Reimers.dk">
//   Copyright � Reimers.dk 2013
//   This source is subject to the Microsoft Public License (Ms-PL).
//   Please see http://go.microsoft.com/fwlink/?LinkID=131993 for details.
//   All other rights reserved.
// </copyright>
// <summary>
//   Defines the ProjectCodeMetrics type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ArchiMetrics.Common.Metrics
{
	using System.Collections.Generic;

	public class ProjectCodeMetrics : CodeMetrics
	{
		public string Project { get; set; }

		public string ProjectPath { get; set; }

		public string Version { get; set; }

		public IEnumerable<INamespaceMetric> Metrics { get; set; }
	}
}
