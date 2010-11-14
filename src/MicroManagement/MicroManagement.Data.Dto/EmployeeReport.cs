using System;

namespace MicroManagement.Data.Dto
{
    public class EmployeeReport
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool Available { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
