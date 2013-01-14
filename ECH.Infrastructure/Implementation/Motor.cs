using ECH.Infrastructure.Interfaces;

namespace ECH.Infrastructure.Implementation
{
    public class Motor : IMotor
    {
        public Motor()
        {
            Activated = GlobalValues.Instance.Activated;
            Rotation = GlobalValues.Instance.Rotation;
            Speed = GlobalValues.Instance.Speed;
        }

        public bool Activated { set; get; }
        public int Speed { set; get; }
        public RotationDirection Rotation { set; get; }
    }
}