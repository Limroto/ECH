using System.Windows.Media;
using ECH.ModuleC.ViewModels;
using ECH.ModuleC.Views;
using Microsoft.Practices.Prism.Events;
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
      _container.RegisterType<ITopView, TopView>();
    }

    public void Initialize()
    {
      TopView topView1 = _container.Resolve<TopView>();
      //TopView topView2 = _container.Resolve<TopView>();

      topView1.Activator(true);
      topView1.BackgroundColor(new SolidColorBrush(Color.FromRgb(0, 255, 0)));
      topView1.Content("Start");

      //topView2.Activator(false);
      //topView1.BackgroundColor(new SolidColorBrush(Color.FromRgb(255, 0, 0)));
      //topView2.Content("Stop");

      IRegion topRegion = _regionManager.Regions["HeaderRegion"];
      topRegion.Add(topView1);
      //topRegion.Add(topView2);
    }
  }
}
