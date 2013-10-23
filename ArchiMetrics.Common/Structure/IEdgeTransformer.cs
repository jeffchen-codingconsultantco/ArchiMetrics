// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IEdgeTransformer.cs" company="Reimers.dk">
//   Copyright � Reimers.dk 2012
//   This source is subject to the Microsoft Public License (Ms-PL).
//   Please see http://go.microsoft.com/fwlink/?LinkID=131993 for details.
//   All other rights reserved.
// </copyright>
// <summary>
//   Defines the IEdgeTransformer type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ArchiMetrics.Common.Structure
{
	using System.Collections.Generic;
	using System.Threading.Tasks;

	public interface IEdgeTransformer
	{
		Task<IEnumerable<MetricsEdgeItem>> TransformAsync(IEnumerable<MetricsEdgeItem> source);
	}
}
