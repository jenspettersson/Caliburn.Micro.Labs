using System;

namespace MicroManagement.Data.Dto
{
    public class EmployeeReport
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }

        public EmployeeReport(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
