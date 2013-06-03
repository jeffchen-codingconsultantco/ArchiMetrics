// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GraphViewModel.cs" company="Roche">
//   Copyright � Roche 2012
//   This source is subject to the Microsoft Public License (Ms-PL).
//   Please see http://go.microsoft.com/fwlink/?LinkID=131993] for details.
//   All other rights reserved.
// </copyright>
// <summary>
//   Defines the GraphViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ArchiMeter.UI.ViewModel
{
	using System.Collections.Generic;
	using System.Linq;

	using ArchiMeter.Analysis;
	using ArchiMeter.Common;

	internal class GraphViewModel : WorkspaceViewModel
	{
		private readonly DependencyAnalyzer _analyzer = new DependencyAnalyzer();
		private readonly IEdgeTransformer _filter;
		private readonly IEdgeItemsRepository _repository;
		private EdgeItem[] _allEdges;
		private ProjectGraph _graphToVisualize;

		public GraphViewModel(IEdgeItemsRepository repository, IEdgeTransformer filter)
		{
			this._repository = repository;
			this._filter = filter;
			this.LoadAllEdges();
		}

		public ProjectGraph GraphToVisualize
		{
			get
			{
				return this._graphToVisualize;
			}

			private set
			{
				if (this._graphToVisualize != value)
				{
					this._graphToVisualize = value;
					this.RaisePropertyChanged();
				}
			}
		}

		public override void Update(bool forceUpdate)
		{
			if (forceUpdate)
			{
				this.LoadAllEdges();
			}
			else
			{
				this.UpdateInternal();
			}
		}

		protected override void Dispose(bool isDisposing)
		{
			this._graphToVisualize = null;
			this._allEdges = null;
			base.Dispose(isDisposing);
		}

		private async void UpdateInternal()
		{
			this.IsLoading = true;
			var g = new ProjectGraph();

			var nonEmptySourceItems = (await this._filter.TransformAsync(this._allEdges))
				.ToArray();

			var circularReferences = (await this._analyzer.GetCircularReferences(nonEmptySourceItems))
				.ToArray();

			var projectVertices = nonEmptySourceItems
				.AsParallel()
				.SelectMany(item =>
					{
						var isCircular = circularReferences.Any(c => c.Contains(item));
						return this.CreateVertices(item, isCircular);
					})
				.GroupBy(v => v.Name)
				.Select(grouping => grouping.First())
				.ToArray();

			var edges =
				nonEmptySourceItems
				.Where(e => !string.IsNullOrWhiteSpace(e.Dependency))
				.Select(
					dependencyItemViewModel =>
					new ProjectEdge(
						projectVertices.First(item => item.Name == dependencyItemViewModel.Dependant), 
						projectVertices.First(item => item.Name == dependencyItemViewModel.Dependency)))
								   .Where(e => e.Target.Name != e.Source.Name);

			foreach (var vertex in projectVertices)
			{
				g.AddVertex(vertex);
			}

			foreach (var edge in edges)
			{
				g.AddEdge(edge);
			}

			this.GraphToVisualize = g;
			this.IsLoading = false;
		}

		private IEnumerable<Vertex> CreateVertices(EdgeItem item, bool isCircular)
		{
			yield return new Vertex(item.Dependant, isCircular, item.DependantComplexity, item.DependantMaintainabilityIndex, item.DependantLinesOfCode);
			if (!string.IsNullOrWhiteSpace(item.Dependency))
			{
				yield return
					new Vertex(item.Dependency, isCircular, item.DependencyComplexity, item.DependencyMaintainabilityIndex, item.DependencyLinesOfCode, item.CodeIssues);
			}
		}

		private async void LoadAllEdges()
		{
			this.IsLoading = true;
			var edges = await this._repository.GetEdgesAsync();
			this._allEdges = edges.Where(e => e.Dependant != e.Dependency).ToArray();
			this.UpdateInternal();
		}
	}
}