using ECH.ModuleB.ViewModels;
using ECH.ModuleB.Views;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;

namespace ECH.ModuleB
{
  public class ModuleB : IModule
  {
    private readonly IUnityContainer _container;
    private readonly IRegionManager _regionManager;

    public ModuleB(IUnityContainer container, IRegionManager regionManager)
    {
      _container = container;
      _regionManager = regionManager;

      RegisterViewsAndServices();
    }

    private void RegisterViewsAndServices()
    {
      _container.RegisterType<MenuViewModel>();
    }

    public void Initialize()
    {
      MenuView topView1 = _container.Resolve<MenuView>();

      IRegion topRegion = _regionManager.Regions["MenuRegion"];
      topRegion.Add(topView1);
    }
  }
}
