using System.ComponentModel.Composition;
using Caliburn.Micro;

namespace ShellWithMenu.Desktop.Content.Shell
{
    [PartCreationPolicy(CreationPolicy.Shared)]
    [Export(typeof(IStatusBarViewModel))]
    public class StatusBarViewModel : Screen, IStatusBarViewModel
    {
        public StatusBarViewModel()
        {
            StatusMessage = "Initialized";
        }

        private string _statusMessage;
        public string StatusMessage
        {
            get { return _statusMessage; }
            set
            {
                _statusMessage = value;
                NotifyOfPropertyChange(() => StatusMessage);
            }
        }
    }

    public interface IStatusBarViewModel
    {
        string StatusMessage { get; set; }
    }
}