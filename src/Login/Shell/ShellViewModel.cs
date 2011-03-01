using System.ComponentModel.Composition;
using Caliburn.Micro;
using Login.Login;

namespace Login.Shell
{
    [Export(typeof (IShell))]
    public class ShellViewModel : Conductor<Screen>, IShell
    {
        private readonly LoginViewModel _firstViewModel;

        [ImportingConstructor]
        public ShellViewModel(LoginViewModel firstViewModel)
        {
            _firstViewModel = firstViewModel;
        }

        protected override void OnInitialize()
        {
            base.OnInitialize();
            ActivateItem(_firstViewModel);
        }
    }
}