using ECH.ModuleB.Views;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;

namespace ECH.ModuleB
{
    public class ModuleB : IModule 
    {
	    public void Initialize()
	    {
				//Register always-avaible controls to the Prism Region Manager
				var regionManager = ServiceLocator.Current.GetInstance<IRegionManager>();

				//regionManager.RegisterViewWithRegion("Region-To-Load-Into", typeof (View-to-load))
				regionManager.RegisterViewWithRegion("MenuRegion", typeof(LightBlueModule));


				//Register on-demand controls with DI container
				//This means view of later-to-come
				var container = ServiceLocator.Current.GetInstance<IUnityContainer>();

				//container.RegisterType<Object, className>("Region-To-Load-Into")
				//container.RegisterType<Object, OrangeModule>("");
	    }
    }
}
