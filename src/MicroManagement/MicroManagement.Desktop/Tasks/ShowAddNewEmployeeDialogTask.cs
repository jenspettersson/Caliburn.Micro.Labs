using System.Collections.Generic;
using Caliburn.Micro;
using MicroManagement.Desktop.Framework.Results;
using MicroManagement.Desktop.ViewModels;

namespace MicroManagement.Desktop.Tasks
{
    public class ShowAddNewEmployeeDialogTask : IGuiTaskItem
    {
        public ShowAddNewEmployeeDialogTask()
        {
            TaskName = "Add new employee";
        }

        public string TaskName { get; set; }

        public IEnumerable<IResult> Execute()
        {
            yield return Show.Child<AddNewEmployeeViewModel>().In<IManageEmployeesViewModel>();
        }
    }
}