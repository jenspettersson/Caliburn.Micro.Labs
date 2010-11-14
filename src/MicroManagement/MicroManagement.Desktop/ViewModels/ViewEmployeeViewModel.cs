using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using Caliburn.Micro;
using MicroManagement.Data.Dto;
using MicroManagement.Desktop.Framework.Results;
using MicroManagement.Desktop.Tasks;

namespace MicroManagement.Desktop.ViewModels
{
    [Export(typeof (ViewEmployeeViewModel)), PartCreationPolicy(CreationPolicy.NonShared)]
    public class ViewEmployeeViewModel : Screen
    {
        private EmployeeReport _employee;
        public EmployeeReport Employee
        {
            get { return _employee; }
        }

        [Import(typeof(IManageEmployeesTasksViewModel), AllowDefault = true)]
        public IManageEmployeesTasksViewModel TaskItemsToolbar { get; set; }

        protected override void OnActivate()
        {
            base.OnActivate();
            TaskItemsToolbar.Tasks = new ObservableCollection<IGuiTaskItem>();

            TaskItemsToolbar.Tasks.Add(new MakeEmployeeAvailableTask { Enabled = !Employee.Available });

            TaskItemsToolbar.Tasks.Add(new MakeEmployeeUnavailableTask{ Enabled = Employee.Available });
        }

        public void WithEmployee(EmployeeReport employee)
        {
            _employee = employee;
        }

        public IEnumerable<IResult> Back()
        {
            yield return Show.Child<ListEmployeesViewModel>().In<IManageEmployeesViewModel>();
        }
    }
}