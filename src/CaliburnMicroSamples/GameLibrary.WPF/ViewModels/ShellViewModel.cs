using System.Collections.Generic;
using System.ComponentModel.Composition;
using Caliburn.Micro;
using GameLibrary.WPF.Framework;
using GameLibrary.WPF.Framework.Results;

namespace GameLibrary.WPF.ViewModels
{
    [Export(typeof (IShell))]
    public class ShellViewModel : Conductor<IScreen>, IShell
    {
        private readonly SearchViewModel _firstScreen;

        [ImportingConstructor]
        public ShellViewModel(SearchViewModel firstScreen)
        {
            _firstScreen = firstScreen;
        }

        protected override void OnInitialize()
        {
            base.OnInitialize();
            ActivateItem(_firstScreen);
        }

        public IEnumerable<IResult> Back()
        {
            yield return Show.Child<SearchViewModel>().In<IShell>();
        }
    }
}