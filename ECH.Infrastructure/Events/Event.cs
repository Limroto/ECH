using ECH.Infrastructure.Implementation;
using Microsoft.Practices.Prism.Events;

namespace ECH.Infrastructure.Events
{
  public class UpdateMotorEvent : CompositePresentationEvent<Motor> { }
  public class STKConnectionEvent : CompositePresentationEvent<StkBoard> { }

  public delegate void UsbStateChangedEventHandler(UsbStateChangedEventArgs e);
}
