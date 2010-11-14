using System;
using System.Collections.Generic;
using Caliburn.Micro;
using MicroManagement.Desktop.Framework.Results;
using MicroManagement.Desktop.ViewModels;

namespace MicroManagement.Desktop.Tasks
{
    public class ShowAddNewEmployeeDialogTask : IGuiTaskItem
    {
        public string TaskName { get; set; }

        public bool Enabled { get; set; }

        public ShowAddNewEmployeeDialogTask()
        {
            Enabled = true;
            TaskName = "Add new employee";
        }

        public IEnumerable<IResult> Execute()
        {
            yield return Show.Child<AddNewEmployeeViewModel>().In<IManageEmployeesViewModel>();
        }
    }

    public class MakeEmployeeAvailableTask : IGuiTaskItem
    {
        public string TaskName { get; set; }

        public bool Enabled { get; set; }

        public MakeEmployeeAvailableTask()
        {
            Enabled = true;
            TaskName = "Activate Employee";
        }

        public IEnumerable<IResult> Execute()
        {
            //Todo: Send Activation command

            yield break;
        }
    }

    public class MakeEmployeeUnavailableTask : IGuiTaskItem
    {
        public string TaskName { get; set; }

        public bool Enabled { get; set; }

        public MakeEmployeeUnavailableTask()
        {
            Enabled = true;
            TaskName = "Deactivate Employee";
        }

        public IEnumerable<IResult> Execute()
        {
            //Todo: Send Deactivation command

            yield break;
        }
    }
}