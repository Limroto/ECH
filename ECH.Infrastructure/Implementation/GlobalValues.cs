using System;
using ECH.Infrastructure.Events;
using ECH.Infrastructure.Interfaces;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Unity;

namespace ECH.Infrastructure.Implementation
{
    public class GlobalValues : IGlobalValues
    {
        private readonly IEventAggregator _eventAggregator;
        private SubscriptionToken _subscriptionToken;
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

        public static void Create(IEventAggregator eventAggregator)
        {
            if(_instance == null)
                _instance = new GlobalValues(eventAggregator);
        }

        private GlobalValues(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;

            Speed = 0;
            Rotation = RotationDirection.Clockwise;
            Activated = false;
            SubscribeToEvents();
        }

        private void SubscribeToEvents()
        {
            var activateMotorEvent = _eventAggregator.GetEvent<UpdateMotorEvent>();

            if (_subscriptionToken != null)
            {
                activateMotorEvent.Unsubscribe(_subscriptionToken);
            }

            _subscriptionToken = activateMotorEvent.Subscribe(UpdateMotorHandler, ThreadOption.BackgroundThread, false);
        }

        private void UpdateMotorHandler(Motor obj)
        {
            Speed = obj.Speed;
            Activated = obj.Activated;
            Rotation = obj.Rotation;
        }

        public bool Activated { get; private set; }
        public int Speed { get; private set; }
        public RotationDirection Rotation { get; private set; }
    }
}