using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Caliburn.Micro;
using MicroManagement.Data;
using MicroManagement.Data.Dto;
using MicroManagement.Desktop.Commands;
using MicroManagement.Desktop.Tasks;

namespace MicroManagement.Desktop.ViewModels
{
    public interface IManageEmployeesViewModel : IScreen { }

    public class ManageEmployeesViewModel : Screen, IManageEmployeesViewModel
    {
        private readonly IEmployeeRepository _employeeRepository;

        public ObservableCollection<EmployeeReport> Employees { get; set; }

        public ManageEmployeesViewModel(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;

            Employees = new ObservableCollection<EmployeeReport>(_employeeRepository.All());
        }
    }
}