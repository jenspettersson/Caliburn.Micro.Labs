using System.ComponentModel.Composition;
using Caliburn.Micro;

namespace MicroManagement.Desktop.ViewModels
{
    [Export(typeof(IShell))]
    public class ShellViewModel : Conductor<IScreen>, IShell
    {
        private readonly IManageEmployeesViewModel _manageEmployeesViewModel;
        private readonly ISettingsViewModel _settingsViewModel;

        [ImportingConstructor]
        public ShellViewModel(IManageEmployeesViewModel manageEmployeesViewModel, ISettingsViewModel settingsViewModel)
        {
            _manageEmployeesViewModel = manageEmployeesViewModel;
            _settingsViewModel = settingsViewModel;
        }

        public void ShowManageEmployees()
        {
            ActivateItem(_manageEmployeesViewModel);
        }

        public void ShowSettings()
        {
            ActivateItem(_settingsViewModel);
        }
    }
}