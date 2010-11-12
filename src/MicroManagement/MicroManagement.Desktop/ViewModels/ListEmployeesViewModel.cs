using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using Caliburn.Micro;
using MicroManagement.Data;
using MicroManagement.Data.Dto;
using MicroManagement.Desktop.Framework.Results;
using MicroManagement.Desktop.Model;

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

        public IEnumerable<IResult> ViewEmployee(EmployeeReport employeeReport)
        {
            yield return Show.Child<ViewEmployeeViewModel>().In<IShell>()
                .Configured(x => x.WithEmployee(employeeReport));
        }
    }
}