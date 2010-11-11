using System;
using System.ComponentModel.Composition;
using Caliburn.Micro;
using ShellWithMenu.Desktop.Content.Shell;

namespace ShellWithMenu.Desktop.Content.Pages
{
    [PartCreationPolicy(CreationPolicy.Shared)]
    [Export(typeof(IPageTwoViewModel))]
    public class PageTwoViewModel : Screen, IPageTwoViewModel
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

        [Import(typeof(IStatusBarViewModel), AllowDefault = true)]
        public IStatusBarViewModel StatusBar { get; set; }

        protected override void OnActivate()
        {
            TimesActivated++;
            TimeActivated = DateTime.Now.ToString();

            StatusBar.StatusMessage = "Page two is activated!";

            base.OnActivate();
        }
    }

    public interface IPageTwoViewModel : IScreen
    {
    }
}