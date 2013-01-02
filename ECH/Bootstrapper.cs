using System;
using System.Windows;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Prism.UnityExtensions;
using Microsoft.Practices.ServiceLocation;

namespace ECH.Shell
{
    public class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return ServiceLocator.Current.GetInstance<Shell>();
        }

        protected override void InitializeShell()
        {
            Application.Current.MainWindow = (Window)Shell;
            Application.Current.MainWindow.Show();
        }

        protected override IModuleCatalog CreateModuleCatalog()
        {
            const string path = "/ECH.Shell;component/ModulesCatalog.xaml";
            var uri = new Uri(path, UriKind.Relative);

            var catalog = Microsoft.Practices.Prism.Modularity.ModuleCatalog.CreateFromXaml(uri);

            return catalog;
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();

            RegisterTypeIfMissing(typeof(IServiceLocator), typeof(UnityServiceLocatorAdapter), true);
            RegisterTypeIfMissing(typeof(IModuleInitializer), typeof(ModuleInitializer), true);
            RegisterTypeIfMissing(typeof(IModuleManager), typeof(ModuleManager), true);
            RegisterTypeIfMissing(typeof(RegionAdapterMappings), typeof(RegionAdapterMappings), true);
            RegisterTypeIfMissing(typeof(IRegionManager), typeof(RegionManager), true);
            RegisterTypeIfMissing(typeof(IEventAggregator), typeof(EventAggregator), true);
            RegisterTypeIfMissing(typeof(IRegionViewRegistry), typeof(RegionViewRegistry), true);
            RegisterTypeIfMissing(typeof(IRegionBehaviorFactory), typeof(RegionBehaviorFactory), true);
        }
    }
}