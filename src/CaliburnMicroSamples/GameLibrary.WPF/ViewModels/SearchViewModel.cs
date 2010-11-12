using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Caliburn.Micro;
using GameLibrary.WPF.Framework;
using GameLibrary.WPF.Framework.Results;
using GameLibrary.WPF.Model;

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

        public IEnumerable<IResult> ExecuteSearch()
        {
            QueryResult<IEnumerable<SearchResult>> search = new SearchGames
                                                                {
                                                                    SearchText = SearchText
                                                                }.AsResult();

            //Todo: yield return Show.Busy();
            yield return search;

            int resultCount = search.Response.Count();

            if (resultCount == 0)
                SearchResults = _noResults.WithTitle(SearchText);
            else if(resultCount == 1 && search.Response.First().Title == SearchText)
            {
                QueryResult<GameDTO> getGame = new GetGame
                                                   {
                                                       Id = search.Response.First().Id
                                                   }.AsResult();

                yield return getGame;
                yield return Show.Child<ExploreGameViewModel>()
                    .In<IShell>()
                    .Configured(x => x.WithGame(getGame.Response));
            }
            else
            {
                SearchResults = _results.With(search.Response);
            }

            //Todo: yield return Show.NotBusy();

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