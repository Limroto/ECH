using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;

namespace ECH.ControllerUnit
{
  public class ModuleControllerUnit : IModule
  {
    private readonly IUnityContainer _container;
    private readonly IRegionManager _regionManager;

    public ModuleControllerUnit(IUnityContainer container, IRegionManager regionManager)
    {
      _container = container;
      _regionManager = regionManager;

      RegisterViewsAndServices();
    }

    private void RegisterViewsAndServices()
    {
      _container.RegisterType<MotorController>();
    }

    public void Initialize()
    {
        base.MemberwiseClone();
    }
  }
}