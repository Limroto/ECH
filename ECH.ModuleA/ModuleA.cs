﻿using ECH.ModuleA.ViewModels;
using ECH.ModuleA.Views;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;

namespace ECH.ModuleA
{
  public class ModuleA : IModule
  {
    private readonly IUnityContainer _container;
    private readonly IRegionManager _regionManager;

    public ModuleA(IUnityContainer container, IRegionManager regionManager)
    {
      _container = container;
      _regionManager = regionManager;

      RegisterViewsAndServices();
    }

    private void RegisterViewsAndServices()
    {
      _container.RegisterType<SettingsViewModel>();
    }

    public void Initialize()
    {
      SettingsView topView1 = _container.Resolve<SettingsView>();

      IRegion topRegion = _regionManager.Regions["MainRegion"];
      topRegion.Add(topView1);
    }
  }
}