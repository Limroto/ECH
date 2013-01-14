using System;
using ECH.Infrastructure.Events;
using ECH.Infrastructure.Interfaces;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Unity;

namespace ECH.Infrastructure.Implementation
{
    public class GlobalValues : IGlobalValues, IMotor
    {
        private readonly IUnityContainer _container;
        private readonly IEventAggregator _eventAggregator;
        private SubscriptionToken subscriptionToken;
        private static GlobalValues _instance;
        public static GlobalValues Instance
        {
            get
            {
                if(_instance == null)
                    throw new Exception("GlobalValues has not been created");
                return _instance;
            }
        }

        public static void Create(IUnityContainer container, IEventAggregator eventAggregator)
        {
            if(_instance == null)
                _instance = new GlobalValues(container, eventAggregator);
        }

        private GlobalValues(IUnityContainer container, IEventAggregator eventAggregator)
        {
            _container = container;
            _eventAggregator = eventAggregator;

            Speed = 0;
            Rotation = RotationDirection.Clockwise;
            Activated = false;
            SubscribeToEvents();
        }

        private void SubscribeToEvents()
        {
            var activateMotorEvent = _eventAggregator.GetEvent<UpdateMotorEvent>();

            if (subscriptionToken != null)
            {
                activateMotorEvent.Unsubscribe(subscriptionToken);
            }

            subscriptionToken = activateMotorEvent.Subscribe(UpdateMotorHandler, ThreadOption.BackgroundThread, false);
        }

        private void UpdateMotorHandler(Motor obj)
        {
            Speed = obj.Speed;
            Activated = obj.Activated;
            Rotation = obj.Rotation;
        }

        public bool Activated { get; private set; }
        public int Speed { get; set; }
        public RotationDirection Rotation { get; set; }
    }
}