using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Linq;
using System.Windows;
using Caliburn.Micro;
using GameLibrary.WPF.Framework;
using GameLibrary.WPF.Model;
using GameLibrary.WPF.Views;

namespace GameLibrary.WPF
{
    public class MefBootstrapper : Bootstrapper<IShell>
    {
        private CompositionContainer _container;

        public MefBootstrapper()
        {
            Func<Type, DependencyObject, object, UIElement> locateView = ViewLocator.LocateForModelType;

            ViewLocator.LocateForModelType = (modelType, displayLocation, context) =>
            {
                return modelType.Equals(typeof(GameDTO))
                    ? new GameView()
                    : locateView(modelType, displayLocation, context);
            };
        }

        protected override void Configure()
        {
            _container = new CompositionContainer(new AggregateCatalog(AssemblySource.Instance.Select(x => new AssemblyCatalog(x)).OfType<ComposablePartCatalog>()));

            var batch = new CompositionBatch();

            batch.AddExportedValue<IWindowManager>(new WindowManager());
            batch.AddExportedValue<IEventAggregator>(new EventAggregator());
            batch.AddExportedValue(_container);

            _container.Compose(batch);
        }

        protected override object GetInstance(Type serviceType, string key)
        {
            string contract = string.IsNullOrEmpty(key) ? AttributedModelServices.GetContractName(serviceType) : key;
            var exports = _container.GetExportedValues<object>(contract);

            if (exports.Count() > 0)
                return exports.First();

            throw new Exception(string.Format("Could not locate any instances of contract {0}.", contract));
        }

        protected override IEnumerable<object> GetAllInstances(Type serviceType)
        {
            return _container.GetExportedValues<object>(AttributedModelServices.GetContractName(serviceType));
        }

        protected override void BuildUp(object instance)
        {
            _container.SatisfyImportsOnce(instance);
        }
    }
}