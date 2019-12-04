using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Microsoft.Extensions.Configuration;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace UAdmin.NHibernate
{
    /// <summary>
    /// Реализация сервиса работы с ORM
    /// </summary>
    public class NHibernateHelper : INhibernateHelper
    {
        /// <summary>
        /// ctor
        /// </summary>
        protected NHibernateHelper()
        {
        }

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="configuration">Конфигурация приложения</param>
        public NHibernateHelper(IConfiguration configuration) : this()
        {
            var config = PostgreSQLConfiguration.PostgreSQL82.ConnectionString(configuration["ConnectionString"]);
            factory = Fluently.Configure()
                .Database(config)
                .Mappings(m =>
                {
                    m.FluentMappings.AddFromAssemblyOf<NHibernateHelper>();
                })
                .ExposeConfiguration(config => new SchemaUpdate(config).Execute(true, true))
                .BuildSessionFactory();
        }

        /// <summary>
        /// Открыть сессию
        /// </summary>
        public ISession OpenSession()
        {
            return factory.OpenSession();
        }

        #region Private

        private ISessionFactory factory;

        #endregion
    }
}