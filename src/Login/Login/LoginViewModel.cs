using System.Collections.Generic;
using System.ComponentModel.Composition;
using Caliburn.Micro;
using Login.Framework.Results;
using Login.Shell;

namespace Login.Login
{
    [Export(typeof (LoginViewModel))]
    public class LoginViewModel : Screen
    {
        private string _userName;
        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
                NotifyOfPropertyChange(() => UserName);
                NotifyOfPropertyChange(() => CanLogin);
            }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                NotifyOfPropertyChange(() => Password);
                NotifyOfPropertyChange(() => CanLogin);
            }
        }

        protected override void OnActivate()
        {
            base.OnActivate();
            UserName = string.Empty;
            Password = string.Empty;
        }

        public IEnumerable<IResult> Login()
        {
            // do some login logic...
            bool success = false;

            if (UserName == "admin" && Password == "admin")
                success = true;

            if (success)
            {
                yield return
                    Show.Child<LoginResultViewModel>().In<IShell>().Configured(c => c.ResultMessage = "Successfully logged in!");
            }
            else
            {
                yield return
                    Show.Child<LoginResultViewModel>().In<IShell>().Configured(c => c.ResultMessage = "You failed to log in!");
            }
        }

        public bool CanLogin
        {
            get { return !string.IsNullOrEmpty(UserName) && !string.IsNullOrEmpty(Password); }
        }
    }
}