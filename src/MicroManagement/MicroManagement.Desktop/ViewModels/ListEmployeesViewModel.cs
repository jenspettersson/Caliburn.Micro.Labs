using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using Caliburn.Micro;
using MicroManagement.Data;
using MicroManagement.Data.Dto;

namespace MicroManagement.Desktop.ViewModels
{
    [Export(typeof (ListEmployeesViewModel))]
    public class ListEmployeesViewModel : Screen
    {
        private readonly IEmployeeRepository _employeeRepository;

        public ObservableCollection<EmployeeReport> Employees { get; set; }

        [ImportingConstructor]
        public ListEmployeesViewModel(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
            Employees = new ObservableCollection<EmployeeReport>(_employeeRepository.All());
        }

        protected override void OnInitialize()
        {
            //TODO: Send a command instead of using the employeeRepository directly
        }
    }
}