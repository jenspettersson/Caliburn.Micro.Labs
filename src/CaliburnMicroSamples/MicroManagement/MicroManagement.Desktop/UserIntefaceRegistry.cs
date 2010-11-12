using Caliburn.Micro;
using MicroManagement.Desktop.Framework;
using MicroManagement.Desktop.ViewModels;
using StructureMap.Configuration.DSL;

namespace MicroManagement.Desktop
{
    public class UserIntefaceRegistry : Registry
    {
        public UserIntefaceRegistry()
        {
            For<IWindowManager>().Use(new WindowManager());
            For<IEventAggregator>().Use(new EventAggregator());

            For<IShell>().Singleton().Use<ShellViewModel>();
            For<IManageEmployeesViewModel>().Singleton().Use<ManageEmployeesViewModel>();
        }
    }
}