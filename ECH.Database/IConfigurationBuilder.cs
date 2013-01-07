using NHibernate;
using NHibernate.Cfg;

namespace ECH.Database
{
    public interface IConfigurationBuilder
    {
        Configuration CreateSessionFactory();
        ISessionFactory SessionFactory { get; }
        void BuildSchema(Configuration config);
    }
}