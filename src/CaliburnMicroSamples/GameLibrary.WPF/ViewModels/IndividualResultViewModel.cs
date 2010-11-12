using System.Collections.Generic;
using Caliburn.Micro;
using GameLibrary.WPF.Framework;
using GameLibrary.WPF.Framework.Results;
using GameLibrary.WPF.Model;

namespace GameLibrary.WPF.ViewModels
{
    public class IndividualResultViewModel : Screen
    {
        private readonly int _number;
        private readonly SearchResult _result;

        public IndividualResultViewModel(SearchResult result, int number)
        {
            _result = result;
            _number = number;
        }

        public int Number
        {
            get { return _number; }
        }

        public string Title
        {
            get { return _result.Title; }
        }

        public IEnumerable<IResult> Open()
        {
            QueryResult<GameDTO> getGame = new GetGame
            {
                Id = _result.Id
            }.AsResult();

            //Todo: yield return Show.Busy();
            yield return getGame;
            yield return Show.Child<ExploreGameViewModel>().In<IShell>()
                .Configured(x => x.WithGame(getGame.Response));
            //Todo: yield return Show.NotBusy();
        }
    }
}