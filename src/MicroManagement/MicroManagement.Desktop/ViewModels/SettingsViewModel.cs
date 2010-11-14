using System.ComponentModel.Composition;
using Caliburn.Micro;

namespace MicroManagement.Desktop.ViewModels
{
    [Export(typeof(ISettingsViewModel)), PartCreationPolicy(CreationPolicy.Shared)]
    public class SettingsViewModel : Screen, ISettingsViewModel
    {
        
    }

    public interface ISettingsViewModel : IScreen
    {
    }
}