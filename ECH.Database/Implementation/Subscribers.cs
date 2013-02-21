using ECH.Infrastructure.Events;
using ECH.Infrastructure.Implementation;
using Microsoft.Practices.Prism.Events;

namespace ECH.Database.Implementation
{
    public class Subscribers
    {
        private readonly IEventAggregator _eventAggregator;
        private SubscriptionToken _subscriptionToken;

        public Subscribers(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;

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
            throw new System.NotImplementedException();
        }
    }
}