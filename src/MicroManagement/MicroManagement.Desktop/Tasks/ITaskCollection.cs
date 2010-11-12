using MicroManagement.Desktop.ViewModels;

namespace MicroManagement.Desktop.Tasks
{
    public interface ITaskCollection
    {
        IGuiTaskItem GetTaskByType<T>();
    }
}