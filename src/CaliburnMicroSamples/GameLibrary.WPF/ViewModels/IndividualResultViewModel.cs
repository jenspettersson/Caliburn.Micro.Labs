using Caliburn.Micro;
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
    }
}