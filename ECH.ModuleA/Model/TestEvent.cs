using System.Media;
using System.Threading;
using ECH.Infrastructure.Events;
using Microsoft.Practices.Prism.Events;

namespace ECH.ModuleA.Model
{
    public class TestEvent
    {
        private readonly IEventAggregator _eventAggregator;
        private SubscriptionToken _subscriptionToken;

        public TestEvent(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            SubscribeToEvents();
        }

        private void SubscribeToEvents()
        {
            var activateMotorEvent = _eventAggregator.GetEvent<ActivateMotorEvent>();

            if (_subscriptionToken != null)
            {
                activateMotorEvent.Unsubscribe(_subscriptionToken);
            }

            _subscriptionToken = activateMotorEvent.Subscribe(ActivateMoterHandler, ThreadOption.BackgroundThread, false);
        }

        #region Handlers

        public void ActivateMoterHandler(Motor ciffer)
        {
            var local = ciffer;
            Thread.Sleep(100);
            SystemSounds.Beep.Play();
        }

        #endregion
    }
}