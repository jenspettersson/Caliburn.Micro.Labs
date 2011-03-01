using System.Collections.Generic;
using System.ComponentModel.Composition;
using Caliburn.Micro;
using Login.Framework.Results;
using Login.Shell;

namespace Login.Login
{
    [Export(typeof (LoginResultViewModel))]
    public class LoginResultViewModel : Screen
    {
        private string _resultMessage;
        public string ResultMessage
        {
            get { return _resultMessage; }
            set
            {
                _resultMessage = value;
                NotifyOfPropertyChange(() => ResultMessage);
            }
        }

        public IEnumerable<IResult> Back()
        {
            yield return Show.Child<LoginViewModel>().In<IShell>();
        }
    }
}