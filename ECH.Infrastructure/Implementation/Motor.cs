using ECH.Infrastructure.Interfaces;
using Microsoft.Practices.Unity;

namespace ECH.Infrastructure.Implementation
{
    public class Motor : IMotor
    {
        private readonly IUnityContainer _container;

        public Motor(IUnityContainer container)
        {
            _container = container;
            Activated = _container.Resolve<IGlobalValues>().Activated;
            Rotation = _container.Resolve<IGlobalValues>().Rotation;
            Speed = _container.Resolve<IGlobalValues>().Speed;
        }

        public bool Activated { set; get; }
        public int Speed { set; get; }
        public RotationDirection Rotation { set; get; }
    }
}