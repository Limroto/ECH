using System.IO;
using ECH.Database.Entities;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace ECH.Database.Implementation
{
    public class ConfigurationBuilder : IConfigurationBuilder
    {
        private ISessionFactory _sessionFactory;
        private const string DbFile = "ECHDatabase";

        public Configuration CreateSessionFactory()
        {
            var conf = Fluently.Configure()
                .Database(
                    SQLiteConfiguration.Standard
                        .UsingFile(DbFile)//.ShowSql
                )
                .Mappings(m =>
                          m.FluentMappings.AddFromAssemblyOf<User>());
            return conf.BuildConfiguration();
        }

        public ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                    _sessionFactory = CreateSessionFactory().BuildSessionFactory();

                return _sessionFactory;
            }
        }

        public void BuildSchema(Configuration config)
        {
            // delete the existing db on each run
            if (File.Exists(DbFile))
                File.Delete(DbFile);

            // this NHibernate tool takes a configuration (with mapping info in)
            // and exports a database schema from it
            new SchemaExport(config)
                .Create(false, true);
        }
    }
}