using ECH.Infrastructure.Events;
using ECH.Infrastructure.Implementation;
using ECH.Infrastructure.Interfaces;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Unity;

namespace ECH.Infrastructure
{
	public class ModuleInfrastructure : IModule 
	{
		private readonly IUnityContainer _container;

		public ModuleInfrastructure(IUnityContainer container)
		{
			_container = container;
		}

		public void Initialize()
		{
		    GlobalValues.Create(_container.Resolve<EventAggregator>());
		    var singleton = GlobalValues.Instance;
            _container.RegisterInstance<IGlobalValues>(singleton);
		    _container.RegisterType<DeviceInsertionEvents>();
			_container.RegisterType<UpdateMotorEvent>();
			_container.RegisterType<Motor>();
			_container.RegisterType<RotationDirection>();

		    ResolveObjects();
		}

	    private void ResolveObjects()
	    {
	        var kits = _container.Resolve<DeviceInsertionEvents>();
        }
	}
}
