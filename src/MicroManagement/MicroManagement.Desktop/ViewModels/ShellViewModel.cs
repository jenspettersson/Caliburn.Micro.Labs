using System.ComponentModel.Composition;
using Caliburn.Micro;
using MicroManagement.Desktop.Framework;

namespace MicroManagement.Desktop.ViewModels
{
    [Export(typeof(IShell))]
    public class ShellViewModel : Conductor<IScreen>, IShell
    {
        private readonly IManageEmployeesViewModel _manageEmployeesViewModel;

        [ImportingConstructor]
        public ShellViewModel(IManageEmployeesViewModel manageEmployeesViewModel)
        {
            _manageEmployeesViewModel = manageEmployeesViewModel;
        }

        public void ShowManageEmployees()
        {
            ActivateItem(_manageEmployeesViewModel);
        }
    }
    
}