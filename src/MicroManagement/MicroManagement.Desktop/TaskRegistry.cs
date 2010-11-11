using MicroManagement.Desktop.Tasks;
using StructureMap.Configuration.DSL;

namespace MicroManagement.Desktop
{
    public class TaskRegistry : Registry
    {
        public TaskRegistry()
        {
            For<ITaskCollection>().Singleton().Use<TaskCollection>();
        }
    }
}