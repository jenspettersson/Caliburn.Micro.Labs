using System.Collections.Generic;
using System.ComponentModel.Composition;
using Caliburn.Micro;
using MicroManagement.Desktop.Commands;
using MicroManagement.Desktop.Framework.Results;
using MicroManagement.Desktop.Model;

namespace MicroManagement.Desktop.ViewModels
{
    [Export(typeof (AddNewEmployeeViewModel)), PartCreationPolicy(CreationPolicy.NonShared)]
    public class AddNewEmployeeViewModel: Screen
    {
        private readonly IEventAggregator _eventAggregator;
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

        [ImportingConstructor]
        public AddNewEmployeeViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
        }

        public IEnumerable<IResult> AddEmployee()
        {
            CommandResult add = new AddEmployee {Name = Name}.AsResult();

            yield return add;

            yield return Show.Child<IManageEmployeesViewModel>().In<IShell>();
        }

        public IEnumerable<IResult> Back()
        {
            yield return Show.Child<IManageEmployeesViewModel>().In<IShell>();
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