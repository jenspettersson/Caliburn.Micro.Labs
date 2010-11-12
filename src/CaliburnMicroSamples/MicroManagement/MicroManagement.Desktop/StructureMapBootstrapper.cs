using System;
using System.Collections.Generic;
using Caliburn.Micro;
using MicroManagement.Desktop.ViewModels;
using StructureMap;

namespace MicroManagement.Desktop
{
    public class StructureMapBootstrapper : Bootstrapper<IShell>
    {
        private IContainer _container;

        protected override void Configure()
        {
            _container = ObjectFactory.Container;

            _container.Configure(x =>
                                     {
                                         x.AddRegistry<UserIntefaceRegistry>();
                                         x.AddRegistry<DataRegistry>();
                                         x.AddRegistry<TaskRegistry>();
                                     });
        }

        protected override object GetInstance(Type serviceType, string key)
        {
            return string.IsNullOrEmpty(key)
                       ? _container.GetInstance(serviceType)
                       : _container.GetInstance(serviceType ?? typeof(object), key);
        }

        protected override IEnumerable<object> GetAllInstances(Type serviceType)
        {
            foreach (var obj in _container.GetAllInstances(serviceType))
            {
                yield return obj;
            }
        }

        protected override void BuildUp(object instance)
        {
            _container.BuildUp(instance);
        }
    }
}