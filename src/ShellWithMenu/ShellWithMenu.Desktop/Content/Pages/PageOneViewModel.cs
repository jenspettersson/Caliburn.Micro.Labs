using System;
using Caliburn.Micro;

namespace ShellWithMenu.Desktop.Content.Pages
{
    public class PageOneViewModel : Screen, IPageOneViewModel
    {
        private string _timeActivated;
        public string TimeActivated
        {
            get { return _timeActivated; }
            set
            {
                _timeActivated = value;
                NotifyOfPropertyChange(() => TimeActivated);
            }
        }

        protected override void OnActivate()
        {
            TimeActivated = DateTime.Now.ToString();
            base.OnActivate();
        }
    }

    public interface IPageOneViewModel
    {
    }
}