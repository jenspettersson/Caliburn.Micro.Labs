using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using Caliburn.Micro;
using MicroManagement.Data;
using MicroManagement.Data.Dto;
using MicroManagement.Desktop.Commands;
using MicroManagement.Desktop.Framework.Results;
using MicroManagement.Desktop.Tasks;

namespace MicroManagement.Desktop.ViewModels
{
    [Export(typeof (ListEmployeesViewModel))]
    public class ListEmployeesViewModel : Screen, IHandle<EmployeeAddedEvent>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IEventAggregator _eventAggregator;

        public ObservableCollection<EmployeeReport> Employees { get; set; }

        [Import(typeof(IManageEmployeesTasksViewModel), AllowDefault = true)]
        public IManageEmployeesTasksViewModel TaskItemsToolbar { get; set; }

        [ImportingConstructor]
        public ListEmployeesViewModel(IEmployeeRepository employeeRepository, IEventAggregator eventAggregator)
        {
            _employeeRepository = employeeRepository;
            _eventAggregator = eventAggregator;

            _eventAggregator.Subscribe(this);

            Employees = new ObservableCollection<EmployeeReport>(_employeeRepository.All());
        }

        public IEnumerable<IResult> ViewEmployee(EmployeeReport employeeReport)
        {
            yield return Show.Child<ViewEmployeeViewModel>().In<IManageEmployeesViewModel>()
                .Configured(x => x.WithEmployee(employeeReport));
        }

        public void Handle(EmployeeAddedEvent message)
        {
            Employees = new ObservableCollection<EmployeeReport>(_employeeRepository.All());
            NotifyOfPropertyChange(() => Employees);
        }

        protected override void OnActivate()
        {
            base.OnActivate();
            TaskItemsToolbar.Tasks = new ObservableCollection<IGuiTaskItem> { new ShowAddNewEmployeeDialogTask() };
        }
    }
}