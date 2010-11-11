using Caliburn.Micro;
using MicroManagement.Desktop.Commands;

namespace MicroManagement.Desktop.Tasks
{
    public class ShowAddNewEmployeeDialogTask : ITaskItem
    {
        private readonly IEventAggregator _eventAggregator;

        public ShowAddNewEmployeeDialogTask(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            TaskName = "Add new employee";
        }

        public string TaskName { get; set; }

        public void Execute()
        {
            _eventAggregator.Publish(new ShowAddNewEmployeeDialogCommand());
        }
    }
}