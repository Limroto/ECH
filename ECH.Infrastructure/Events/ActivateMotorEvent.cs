using Microsoft.Practices.Prism.Events;

namespace ECH.Infrastructure.Events
{
  public class ActivateMotorEvent : CompositePresentationEvent<Motor>
  { }

  public class Motor
  {
    public Motor()
    {
      Speed = 100;
      Rotation = RotationDirection.Clockwise;
    }

    public bool Activated { set; get; }
    public int Speed { set; get; }
    public RotationDirection Rotation { set; get; }
  }

  public enum RotationDirection
  {
    Clockwise = 1, AntiClockwise = 2
  };
}
