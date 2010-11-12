using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using MicroManagement.Data.Dto;

namespace MicroManagement.Data
{
    [Export(typeof (IEmployeeRepository)), PartCreationPolicy(CreationPolicy.Shared)]
    public class FakeEmployeeRepository : IEmployeeRepository
    {
        public IList<EmployeeReport> Employees;

        public FakeEmployeeRepository()
        {
            InitializeFakeEmployeeRepository();
        }

        private void InitializeFakeEmployeeRepository()
        {
            Employees = new List<EmployeeReport>();

            Employees.Add(new EmployeeReport(Guid.NewGuid(), "Jens Pettersson"));
            Employees.Add(new EmployeeReport(Guid.NewGuid(), "Mr Sir Developer"));
        }

        public IEnumerable<EmployeeReport> All()
        {
            return Employees;
        }

        public IEnumerable<EmployeeReport> GetByExample(EmployeeReport example)
        {
            return Employees.Where(x => x.Id == example.Id);
        }

        public void Save(EmployeeReport employee)
        {
            Employees.Add(employee);
        }
    }


}
