using System.Collections.Generic;
using Caliburn.Micro;

namespace MicroManagement.Desktop.Tasks
{
    public interface IGuiTaskItem
    {
        string TaskName { get; set; }
        IEnumerable<IResult> Execute();
    }
}