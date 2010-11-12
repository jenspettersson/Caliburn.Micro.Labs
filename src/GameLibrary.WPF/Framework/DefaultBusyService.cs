using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Media;
using Caliburn.Micro;

namespace GameLibrary.WPF.Framework
{
    [Export(typeof (IBusyService))]
    public class DefaultBusyService : IBusyService
    {
        public static string BusyIndicatorName = "busyIndicator";
        private readonly object _defaultKey = new object();

        private readonly Dictionary<object, BusyInfo> _loaders = new Dictionary<object, BusyInfo>();
        private readonly object _lockObject = new object();

        private readonly IWindowManager _windowManager;

        [ImportingConstructor]
        public DefaultBusyService(IWindowManager windowManager)
        {
            _windowManager = windowManager;
        }

        #region IBusyService Members

        public void MarkAsBusy(object sourceViewModel, object busyViewModel)
        {
            sourceViewModel = sourceViewModel ?? _defaultKey;

            if (_loaders.ContainsKey(sourceViewModel))
            {
                BusyInfo info = _loaders[sourceViewModel];
                info.BusyViewModel = busyViewModel;
                UpdateLoader(info);
            }
            else
            {
                UIElement busyIndicator = TryFindBusyIndicator(sourceViewModel);

                if (busyIndicator == null)
                {
                    var notifier = busyViewModel as IActivate;
                    if (notifier == null)
                        return;

                    notifier.Activated += (o, e) =>
                    {
                        if (e.WasInitialized)
                        {
                            var info = new BusyInfo { BusyViewModel = busyViewModel };
                            _loaders[sourceViewModel] = info;
                            UpdateLoader(info);
                        }
                    };

                    _windowManager.ShowDialog(busyViewModel, null);
                }
                else
                {
                    var info = new BusyInfo { BusyIndicator = busyIndicator, BusyViewModel = busyViewModel };
                    _loaders[sourceViewModel] = info;
                    ToggleBusyIndicator(info, true);
                    UpdateLoader(info);
                }
            }
        }

        public void MarkAsNotBusy(object sourceViewModel)
        {
            sourceViewModel = sourceViewModel ?? _defaultKey;

            if (!_loaders.ContainsKey(sourceViewModel)) return;

            BusyInfo info = _loaders[sourceViewModel];

            lock (_lockObject)
            {
                info.Depth--;

                if (info.Depth == 0)
                {
                    _loaders.Remove(sourceViewModel);
                    ToggleBusyIndicator(info, false);
                }
            }
        }

        #endregion

        private void UpdateLoader(BusyInfo info)
        {
            lock (_lockObject)
            {
                info.Depth++;
            }

            if (info.BusyViewModel == null || info.BusyIndicator == null)
                return;

            Type indicatorType = info.BusyIndicator.GetType();
            PropertyInfo content = indicatorType.GetProperty("BusyContent");

            if (content == null)
            {
                ContentPropertyAttribute contentProperty = indicatorType.GetAttributes<ContentPropertyAttribute>(true)
                    .FirstOrDefault();

                if (contentProperty == null)
                    return;

                content = indicatorType.GetProperty(contentProperty.Name);
            }

            content.SetValue(info.BusyIndicator, info.BusyViewModel, null);
        }

        private void ToggleBusyIndicator(BusyInfo info, bool isBusy)
        {
            if (info.BusyIndicator != null)
            {
                PropertyInfo busyProperty = info.BusyIndicator.GetType().GetProperty("IsBusy");
                if (busyProperty != null)
                    busyProperty.SetValue(info.BusyIndicator, isBusy, null);
                else info.BusyIndicator.Visibility = isBusy ? Visibility.Visible : Visibility.Collapsed;
            }
            else if (!isBusy)
            {
                MethodInfo close = info.BusyViewModel.GetType().GetMethod("Close", Type.EmptyTypes);
                if (close != null)
                    close.Invoke(info.BusyViewModel, null);
            }
        }

        private UIElement TryFindBusyIndicator(object viewModel)
        {
            FrameworkElement view = GetView(viewModel);
            if (view == null)
            {
                return null;
            }

            UIElement busyIndicator = null;

            while (view != null && busyIndicator == null)
            {
                busyIndicator = view.FindName(BusyIndicatorName) as UIElement;
                view = VisualTreeHelper.GetParent(view) as FrameworkElement;
            }

            return busyIndicator;
        }

        private FrameworkElement GetView(object viewModel)
        {
            var viewAware = viewModel as IViewAware;
            if (viewAware == null)
                return null;

            return viewAware.GetView(null) as FrameworkElement;
        }

        #region Nested type: BusyInfo

        private class BusyInfo
        {
            public UIElement BusyIndicator { get; set; }
            public object BusyViewModel { get; set; }
            public int Depth { get; set; }
        }

        #endregion
    }
}