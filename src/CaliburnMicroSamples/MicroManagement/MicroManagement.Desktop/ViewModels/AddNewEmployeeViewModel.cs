using System.ComponentModel.Composition;
using Caliburn.Micro;

namespace MicroManagement.Desktop.ViewModels
{
    [Export(typeof (IAddNewEmployeeViewModel))]
    public class AddNewEmployeeViewModel: Screen, IAddNewEmployeeViewModel
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                NotifyOfPropertyChange(() => Name);
                NotifyOfPropertyChange(() => CanAddEmployee);
            }
        }

        public void AddEmployee()
        {
            
        }

        public bool CanAddEmployee
        {
            get { return !string.IsNullOrEmpty(Name); }
        }
    }

    public interface IAddNewEmployeeViewModel : IScreen
    {
    }
}