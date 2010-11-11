using MicroManagement.Desktop.ViewModels;

namespace MicroManagement.Desktop.Tasks
{
    public interface ITaskCollection
    {
        ITaskItem GetTaskByType<T>();
    }
}