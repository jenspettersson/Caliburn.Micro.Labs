using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using Caliburn.Micro;
using MicroManagement.Desktop.Tasks;

namespace MicroManagement.Desktop.ViewModels
{
    public interface IManageEmployeesViewModel : IConductor, IScreen { }

    [Export(typeof (IManageEmployeesViewModel)), PartCreationPolicy(CreationPolicy.Shared)]
    public class ManageEmployeesViewModel : Conductor<IScreen>, IManageEmployeesViewModel
    {
        private readonly ListEmployeesViewModel _listEmployeesViewModel;

        [Import(typeof(IManageEmployeesTasksViewModel), AllowDefault = true)]
        public IManageEmployeesTasksViewModel TaskItemsToolbar { get; set; }

        [ImportingConstructor]
        public ManageEmployeesViewModel(ListEmployeesViewModel listEmployeesViewModel)
        {
            _listEmployeesViewModel = listEmployeesViewModel;
        }

        protected override void OnInitialize()
        {
            base.OnInitialize();
            ActivateItem(_listEmployeesViewModel);
        }
    }
}