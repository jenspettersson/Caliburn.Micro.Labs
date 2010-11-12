using MicroManagement.Desktop.Model;

namespace MicroManagement.Desktop.Commands
{
    public class AddEmployee : ICommand
    {
        public string Name { get; set; }
    }
}