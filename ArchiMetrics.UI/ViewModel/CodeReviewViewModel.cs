// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CodeReviewViewModel.cs" company="Reimers.dk">
//   Copyright � Reimers.dk 2013
//   This source is subject to the Microsoft Public License (Ms-PL).
//   Please see http://go.microsoft.com/fwlink/?LinkID=131993 for details.
//   All other rights reserved.
// </copyright>
// <summary>
//   Defines the CodeReviewViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ArchiMetrics.UI.ViewModel
{
	using System;
	using System.Collections.ObjectModel;
	using System.Linq;
	using System.Threading;
	using System.Windows.Data;
	using ArchiMetrics.Common.CodeReview;
	using ArchiMetrics.Common.Structure;

	public sealed class CodeReviewViewModel : ViewModelBase
	{
		private readonly ISolutionEdgeItemsRepositoryConfig _config;
		private readonly ICodeErrorRepository _repository;
		private int _brokenCode;
		private int _errorsShown;
		private int _filesWithErrors;
		private ObservableCollection<EvaluationResult> _codeErrors;
		private CancellationTokenSource _tokenSource;

		public CodeReviewViewModel(ICodeErrorRepository repository, ISolutionEdgeItemsRepositoryConfig config)
			: base(config)
		{
			_repository = repository;
			_config = config;
			IsLoading = true;
			CodeErrors = new ObservableCollection<EvaluationResult>();
			Update(true);
		}

		public int BrokenCode
		{
			get
			{
				return _brokenCode;
			}

			set
			{
				if (_brokenCode != value)
				{
					_brokenCode = value;
					RaisePropertyChanged();
				}
			}
		}

		public int ErrorsShown
		{
			get
			{
				return _errorsShown;
			}

			set
			{
				if (_errorsShown != value)
				{
					_errorsShown = value;
					RaisePropertyChanged();
				}
			}
		}

		public int FilesWithErrors
		{
			get
			{
				return _filesWithErrors;
			}

			set
			{
				if (_filesWithErrors != value)
				{
					_filesWithErrors = value;
					RaisePropertyChanged();
				}
			}
		}

		public ObservableCollection<EvaluationResult> CodeErrors
		{
			get
			{
				return _codeErrors;
			}

			private set
			{
				_codeErrors = value;
				RaisePropertyChanged();
			}
		}

		protected async override void Update(bool forceUpdate)
		{
			if (_tokenSource != null)
			{
				_tokenSource.Cancel(false);
				_tokenSource.Dispose();
			}

			_tokenSource = new CancellationTokenSource();
			var newErrors = new ObservableCollection<EvaluationResult>();
			try
			{
				ErrorsShown = 0;
				CodeErrors.Clear();

				var errors = await _repository.GetErrors(_config.Path, _tokenSource.Token);
				var results = errors.Where(x => x.Title != "Multiple Asserts in Test" || x.ErrorCount != 1).ToArray();
				foreach (var result in results)
				{
					newErrors.Add(result);
				}

				if (newErrors.Count == 0)
				{
					newErrors.Add(new EvaluationResult { Title = "No Errors", Quality = CodeQuality.Good });
				}

				FilesWithErrors = results.GroupBy(x => x.FilePath).Select(x => x.Key).Count();
				BrokenCode = (int)(results
					.Where(x => x.Quality == CodeQuality.Broken || x.Quality == CodeQuality.Incompetent)
					.Sum(x => (double)x.LinesOfCodeAffected)
								   + results.Where(x => x.Quality == CodeQuality.NeedsReEngineering)
									   .Sum(x => x.LinesOfCodeAffected * .5)
								   + results.Where(x => x.Quality == CodeQuality.NeedsRefactoring)
									   .Sum(x => x.LinesOfCodeAffected * .2));
			}
			catch (Exception exception)
			{
				var result = new EvaluationResult
									   {
										   Quality = CodeQuality.Broken,
										   Title = exception.Message,
										   Snippet = exception.StackTrace
									   };
				newErrors.Add(result);
				IsLoading = false;
			}
			finally
			{
				IsLoading = false;
				CodeErrors = newErrors;
				ErrorsShown = newErrors.Count;
			}
		}
	}
}
