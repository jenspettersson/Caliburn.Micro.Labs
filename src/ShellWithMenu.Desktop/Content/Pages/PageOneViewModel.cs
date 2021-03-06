using System;
using System.ComponentModel.Composition;
using Caliburn.Micro;
using ShellWithMenu.Desktop.Content.Shell;

namespace ShellWithMenu.Desktop.Content.Pages
{
    [PartCreationPolicy(CreationPolicy.Shared)]
    [Export(typeof(IPageOneViewModel))]
    public class PageOneViewModel : Screen, IPageOneViewModel
    {
        public PageOneViewModel()
        {
            TimesActivated = 0;
        }

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

        private int _timesActivated;
        public int TimesActivated
        {
            get { return _timesActivated; }
            set
            {
                _timesActivated = value;
                NotifyOfPropertyChange(() => TimesActivated);
            }
        }

        protected override void OnActivate()
        {
            TimesActivated++;
            TimeActivated = DateTime.Now.ToString();

            StatusBar.StatusMessage = "PageOne is activated!";

            base.OnActivate();
        }

        [Import(typeof(IStatusBarViewModel), AllowDefault = true)]
        public IStatusBarViewModel StatusBar { get; set; }
    }

    public interface IPageOneViewModel : IScreen
    {
    }
}