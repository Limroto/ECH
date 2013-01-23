using ECH.Database.Entities;
using ECH.Database.Interfaces;
using ECH.Infrastructure.Implementation;
using NHibernate;

namespace ECH.Database.Implementation
{
    public class Queries : IQueries 
    {
        private readonly ISessionFactory _factory;

        public Queries(ISessionFactory factory)
        {
            _factory = factory;
        }

        public void LogUpdateMotorEvent(Motor motor)
        {
            var log = new Settings
                {
                    Active = motor.Activated,
                    Direction = (motor.Rotation == RotationDirection.Clockwise ? "Clockwise" : "AntiClockwise"),
                    Speed = motor.Speed
                };
            
            using(var session = _factory.OpenSession())
            {
                using(var transaction = session.BeginTransaction())
                {
                    session.SaveOrUpdate(log);
                    transaction.Commit();
                }
            }
        }
    }
}