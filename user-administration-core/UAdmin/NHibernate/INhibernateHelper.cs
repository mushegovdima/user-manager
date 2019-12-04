using NHibernate;

namespace UAdmin.NHibernate
{
    //Сервис работы с ORM
    public interface INhibernateHelper
    {
        /// <summary>
        /// Открыть сессию
        /// </summary>
        ISession OpenSession();
    }
}
