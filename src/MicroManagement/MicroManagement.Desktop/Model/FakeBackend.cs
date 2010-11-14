using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Reflection;
using System.Threading;
using Caliburn.Micro;
using MicroManagement.Data;
using MicroManagement.Data.Dto;
using MicroManagement.Desktop.Commands;

namespace MicroManagement.Desktop.Model
{
    [Export(typeof (IBackend))]
    public class FakeBackend : IBackend
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IEventAggregator _eventAggregator;

        [ImportingConstructor]
        public FakeBackend(IEmployeeRepository employeeRepository, IEventAggregator eventAggregator)
        {
            _employeeRepository = employeeRepository;
            _eventAggregator = eventAggregator;
        }

        public void Send<TResponse>(IQuery<TResponse> query, Action<TResponse> reply)
        {
            Invoke(query, query, reply);
        }

        public void Send(ICommand command)
        {
            Invoke(command, command);
        }

        private readonly IEnumerable<MethodInfo> _methods =
            typeof(FakeBackend).GetMethods().Where(x => x.Name == "Handle");

        private void Invoke(object request, params object[] args)
        {
            ThreadPool.QueueUserWorkItem(state =>
            {
                Thread.Sleep(1000);

                Type requestType = request.GetType();
                MethodInfo handler =
                    _methods.Where(
                        x =>
                        requestType.IsAssignableFrom(
                            x.GetParameters().First().ParameterType)).First();

                handler.Invoke(this, args);
            });
        }

        public void Handle(GetEmployee search, Action<IEnumerable<EmployeeReport>> reply)
        {
            reply(_employeeRepository.GetByExample(new EmployeeReport{ Id = search.Id}));
        }

        public void Handle(AddEmployee addEmployee)
        {
            var employeeReport = new EmployeeReport {Id = Guid.NewGuid(), Name = addEmployee.Name};
            _employeeRepository.Save(employeeReport);

            _eventAggregator.Publish(new EmployeeAddedEvent());
        }
    }
}