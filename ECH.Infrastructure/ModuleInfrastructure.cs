using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECH.Infrastructure.Events;
using ECH.Infrastructure.Implementation;
using ECH.Infrastructure.Interfaces;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
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
		    GlobalValues.Create(/*_container.Resolve<UnityContainer>(),*/ _container.Resolve<EventAggregator>());
		    var singleton = GlobalValues.Instance;
            _container.RegisterInstance<IGlobalValues>(singleton);
			_container.RegisterType<UpdateMotorEvent>();
			_container.RegisterType<Motor>();
			_container.RegisterType<RotationDirection>();
		}
	}
}
