using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Reflection;
using System.Threading;
using MicroManagement.Data;
using MicroManagement.Data.Dto;

namespace MicroManagement.Desktop.Model
{
    public class FakeBackend : IBackend
    {
        private readonly IEmployeeRepository _employeeRepository;

        [ImportingConstructor]
        public FakeBackend(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
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
            reply(_employeeRepository.GetByExample(new EmployeeReport(search.Id)));
        }
    }
}