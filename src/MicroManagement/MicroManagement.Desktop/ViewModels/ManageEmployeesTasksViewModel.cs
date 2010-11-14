using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using Caliburn.Micro;
using MicroManagement.Desktop.Tasks;

namespace MicroManagement.Desktop.ViewModels
{
    [Export(typeof(IManageEmployeesTasksViewModel)), PartCreationPolicy(CreationPolicy.Shared)]
    public class ManageEmployeesTasksViewModel : Screen, IManageEmployeesTasksViewModel
    {
        private ObservableCollection<IGuiTaskItem> _tasks;
        public ObservableCollection<IGuiTaskItem> Tasks
        {
            get { return _tasks; }
            set
            {
                _tasks = value;
                NotifyOfPropertyChange(() => Tasks);
            }
        }
    }

    public interface IManageEmployeesTasksViewModel
    {
        ObservableCollection<IGuiTaskItem> Tasks { get; set; }
    }
}