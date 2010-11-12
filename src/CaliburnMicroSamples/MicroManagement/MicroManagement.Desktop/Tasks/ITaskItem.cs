namespace MicroManagement.Desktop.Tasks
{
    public interface ITaskItem
    {
        string TaskName { get; set; }
        void Execute();
    }
}