using System.ComponentModel.Composition;
using Caliburn.Micro;
using MicroManagement.Data.Dto;

namespace MicroManagement.Desktop.ViewModels
{
    [Export(typeof (ViewEmployeeViewModel))]
    public class ViewEmployeeViewModel : Screen
    {
        private EmployeeReport _employee;
        public EmployeeReport Employee
        {
            get { return _employee; }
        }

        public void WithEmployee(EmployeeReport employee)
        {
            _employee = employee;
        }
    }
}