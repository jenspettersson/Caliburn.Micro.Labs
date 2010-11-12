using System.Collections.Generic;
using System.Linq;
using Caliburn.Micro;
using StructureMap;

namespace MicroManagement.Desktop.Tasks
{
    public class TaskCollection : ITaskCollection
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly IContainer _container;
        public IList<IGuiTaskItem> TaskList { get; private set; }

        public TaskCollection(IEventAggregator eventAggregator, IContainer container)
        {
            //_eventAggregator = eventAggregator;
            //_container = container;
            //TaskList = new List<ITaskItem>();

            //TaskList.Add(new ShowAddNewEmployeeDialogTask(_eventAggregator));
        }

        public IGuiTaskItem GetTaskByType<T>()
        {
            return TaskList.First(x => x.GetType() == typeof (T));
        }
    }
}