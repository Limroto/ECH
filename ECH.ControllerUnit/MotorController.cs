using System.Media;
using ECH.Infrastructure;
using ECH.Infrastructure.Events;
using ECH.Infrastructure.Implementation;
using Microsoft.Practices.Prism.Events;

namespace ECH.ControllerUnit
{
    public class MotorController
    {
      private readonly IEventAggregator _eventAggregator;
      private SubscriptionToken subscriptionToken;

      public MotorController(IEventAggregator eventAggregator)
      {
        _eventAggregator = eventAggregator;

        SubscribeToEvents();
      }

      private void SubscribeToEvents()
      {
        var activateMotorEvent = _eventAggregator.GetEvent<UpdateMotorEvent>();

        if (subscriptionToken != null)
        {
          activateMotorEvent.Unsubscribe(subscriptionToken);
        }

        subscriptionToken = activateMotorEvent.Subscribe(ActivateMoterHandler, ThreadOption.BackgroundThread, false);
      }

      #region Handlers
      
      public void ActivateMoterHandler(Motor motor)
      {
        SystemSounds.Asterisk.Play();
      }

      #endregion
    }
}
