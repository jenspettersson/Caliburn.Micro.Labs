using System.ComponentModel.Composition;
using Caliburn.Micro;
using GameLibrary.WPF.Framework;
using GameLibrary.WPF.Framework.Results;

namespace GameLibrary.WPF.ViewModels
{
    [Export(typeof (NoResultsViewModel))]
    public class NoResultsViewModel
    {
        private string _searchText;

        public NoResultsViewModel WithTitle(string searchText)
        {
            _searchText = searchText;
            return this;
        }

        public IResult AddGame()
        {
            return Show.Child<AddGameViewModel>()
                .In<IShell>()
                .Configured(x => x.Title = _searchText);
        }
    }
}