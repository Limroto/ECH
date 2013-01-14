using ECH.Infrastructure.Implementation;

namespace ECH.Infrastructure.Interfaces
{
    public interface IMotor
    {
        bool Activated { get; }
        int Speed { get; }
        RotationDirection Rotation { get; }
    }
}