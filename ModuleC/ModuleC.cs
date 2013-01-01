using ECH.ModuleC.ViewModels;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;

namespace ECH.ModuleC
{
  public class ModuleC : IModule
  {
    private readonly IUnityContainer _container;
    private readonly IRegionManager _regionManager;

    public ModuleC(IUnityContainer container, IRegionManager regionManager)
    {
      _container = container;
      _regionManager = regionManager;

      RegisterViewsAndServices();
    }

    private void RegisterViewsAndServices()
    {
      _container.RegisterType<TopViewModel>();
    }

    public void Initialize()
    {
      TopView topView1 = _container.Resolve<TopView>();

      IRegion topRegion = _regionManager.Regions["HeaderRegion"];
      topRegion.Add(topView1);
    }
  }
}
