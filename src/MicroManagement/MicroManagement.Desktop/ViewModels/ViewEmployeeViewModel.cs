using System.Collections.Generic;
using System.ComponentModel.Composition;
using Caliburn.Micro;
using MicroManagement.Data.Dto;
using MicroManagement.Desktop.Framework.Results;

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

        public void WithEmployee(EmployeeReport employee)
        {
            _employee = employee;
        }

        public IEnumerable<IResult> Back()
        {
            yield return Show.Child<IManageEmployeesViewModel>().In<IShell>();
        }
    }
}