using System.Collections.Generic;
using MicroManagement.Data.Dto;

namespace MicroManagement.Data
{
    public interface IEmployeeRepository
    {
        IEnumerable<EmployeeReport>All();
        IEnumerable<EmployeeReport> GetByExample(EmployeeReport example);
        void Save(EmployeeReport employee);
    }
}