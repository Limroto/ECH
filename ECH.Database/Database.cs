using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Unity;

namespace ECH.Database
{
    public class Database : IModule
    {
        private readonly IUnityContainer _container;

        public Database(IUnityContainer container)
        {
            _container = container;

            RegisterViewsAndServices();
        }

        private void RegisterViewsAndServices()
        {
            _container.RegisterType<IConfigurationBuilder, ConfigurationBuilder>();
        }

        public void Initialize()
        {
            ConfigurationBuilder cfg = _container.Resolve<ConfigurationBuilder>();
        }
    }
}