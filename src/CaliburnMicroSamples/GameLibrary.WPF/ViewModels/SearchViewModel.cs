using System.ComponentModel.Composition;
using Caliburn.Micro;
using GameLibrary.WPF.Framework;
using GameLibrary.WPF.Framework.Results;

namespace GameLibrary.WPF.ViewModels
{
    [Export(typeof (SearchViewModel))]
    public class SearchViewModel : Screen
    {
        private readonly NoResultsViewModel _noResults;
        private readonly ResultsViewModel _results;

        private object _searchResults;
        private string _searchText;

        [ImportingConstructor]
        public SearchViewModel(NoResultsViewModel noResults, ResultsViewModel results)
        {
            _noResults = noResults;
            _results = results;
        }

        public string SearchText
        {
            get { return _searchText; }
            set
            {
                _searchText = value;
                NotifyOfPropertyChange(() => SearchText);
                NotifyOfPropertyChange(() => CanExecuteSearch);
            }
        }

        public object SearchResults
        {
            get { return _searchResults; }
            set
            {
                _searchResults = value;
                NotifyOfPropertyChange(() => SearchResults);
            }
        }

        public bool CanExecuteSearch
        {
            get { return !string.IsNullOrEmpty(SearchText); }
        }

        public IResult AddGame()
        {
            return Show.Child<AddGameViewModel>()
                .In<IShell>()
                .Configured(x => x.Title = "New Game");
        }

        protected override void OnActivate()
        {
            SearchText = null;
            SearchResults = null;

            base.OnActivate();
        }
    }
}