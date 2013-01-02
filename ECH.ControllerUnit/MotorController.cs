using System.Media;
using System.Threading;
using ECH.Infrastructure.Events;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Unity;

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
        var activateMotorEvent = _eventAggregator.GetEvent<ActivateMotorEvent>();

        if (subscriptionToken != null)
        {
          activateMotorEvent.Unsubscribe(subscriptionToken);
        }

        subscriptionToken = activateMotorEvent.Subscribe(ActivateMoterHandler,  ThreadOption.UIThread, false);
      }

      #region Handlers
      
      public void ActivateMoterHandler(Motor motor)
      {
        SystemSounds.Asterisk.Play();
        Thread.Sleep(300);
      }

      #endregion
    }
}
