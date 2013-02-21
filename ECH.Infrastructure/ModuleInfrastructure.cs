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
            _container.RegisterInstance<IGlobalValues>(singleton); //Singleton with parameter

		    _container.RegisterType<DeviceInsertionEvents>(); //Event
			_container.RegisterType<UpdateMotorEvent>(); //Event
			_container.RegisterType<IMotor, Motor>();
			_container.RegisterType<RotationDirection>(); //enum

		    ResolveObjects();
		}

	    private void ResolveObjects()
	    {
	        _container.Resolve<DeviceInsertionEvents>(); //Event
        }
	}
}
