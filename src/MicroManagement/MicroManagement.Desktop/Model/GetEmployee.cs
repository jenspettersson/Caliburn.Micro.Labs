using System;
using System.Collections.Generic;
using MicroManagement.Data.Dto;

namespace MicroManagement.Desktop.Model
{
    public class GetEmployee : IQuery<IEnumerable<EmployeeReport>>
    {
        public Guid Id { get; set; }
    }
}