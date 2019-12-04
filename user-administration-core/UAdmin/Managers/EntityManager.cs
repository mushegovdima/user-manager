using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UAdmin.Models;
using UAdmin.NHibernate;

namespace UAdmin.Managers
{
    /// <summary>
    /// Реализация менеджера <see cref="IEntityManager{T}"/>
    /// </summary>
    /// <typeparam name="T">Сущность</typeparam>
    public class EntityManager<T> : IEntityManager<T> where T : Entity
    {
        private readonly INhibernateHelper NHibernateHelper;

        public EntityManager(INhibernateHelper nhibernateHelper)
        {
            NHibernateHelper = nhibernateHelper;
        }

        public T Create()
        {
            return Activator.CreateInstance<T>();
        }

        public void Save(T entity)
        {
            var session = NHibernateHelper.OpenSession();
            session.FlushMode = FlushMode.Commit;
            using (var transaction = session.BeginTransaction())
            {
                entity = session.Merge<T>(entity);
                session.SaveOrUpdate(entity);
                transaction.Commit();
            }
        }

        public void Delete(T entity)
        {
            var session = NHibernateHelper.OpenSession();
            session.FlushMode = FlushMode.Commit;
            using (var transaction = session.BeginTransaction())
            {
                entity = session.Merge<T>(entity);
                session.Delete(entity);
                transaction.Commit();
            }
            session.Close();
        }

        public T Load(long id)
        {
            var session = NHibernateHelper.OpenSession();
            return session.Load<T>(id, LockMode.Read);
        }
        public bool IsNew(T entity)
        {
            return entity != null && !(entity.Id > 0);
        }

        public long Count()
        {
            var session = NHibernateHelper.OpenSession();
            var criteria = session.CreateCriteria<T>();
            criteria.SetProjection(Projections.RowCountInt64());
            var result = Convert.ToInt64(criteria.UniqueResult());
            return result;
        }

        public Task<IList<T>> FindAll()
        {
            var session = NHibernateHelper.OpenSession();
            var criteria = session.CreateCriteria<T>();
            return criteria.ListAsync<T>();
        }
    }
}
