using System.Collections.Generic;
using System.ComponentModel.Composition;
using Caliburn.Micro;
using MicroManagement.Desktop.Tasks;

namespace MicroManagement.Desktop.ViewModels
{
    public interface IManageEmployeesViewModel : IConductor, IScreen { }

    [Export(typeof (IManageEmployeesViewModel))]
    public class ManageEmployeesViewModel : Conductor<IScreen>, IManageEmployeesViewModel
    {
        private readonly ListEmployeesViewModel _listEmployeesViewModel;
        public IList<IGuiTaskItem> Tasks { get; set; }

        [ImportingConstructor]
        public ManageEmployeesViewModel(ListEmployeesViewModel listEmployeesViewModel)
        {
            _listEmployeesViewModel = listEmployeesViewModel;

            SetupTasks();
        }

        private void SetupTasks()
        {
            Tasks = new List<IGuiTaskItem> { new ShowAddNewEmployeeDialogTask() };
        }

        protected override void OnInitialize()
        {
            base.OnInitialize();
            ActivateItem(_listEmployeesViewModel);
        }
    }
}