using System.Collections.Generic;
using System.Threading.Tasks;
using UAdmin.Models;

namespace UAdmin.Managers
{
    /// <summary>
    /// Менеджер работы с сущностями
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IEntityManager<T> where T : IEntity
    {
        /// <summary>
        /// Удалить
        /// </summary>
        /// <param name="entity"></param>
        void Delete(T entity);

        /// <summary>
        /// Сохранить
        /// </summary>
        /// <param name="entity"></param>
        void Save(T entity);

        /// <summary>
        /// Загрузить
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Сущность</returns>
        T Load(long id);

        /// <summary>
        /// Создать новый объект (без сохранения)
        /// </summary>
        /// <returns>Сущность</returns>
        T Create();

        /// <summary>
        /// Не сохранялась в базе
        /// </summary>
        /// <param name="entity"></param>
        bool IsNew(T entity);

        /// <summary>
        /// Количество объектов в таблице
        /// </summary>
        /// <returns>Количество</returns>
        long Count();

        /// <summary>
        /// Получить все записи сущности асинхронно
        /// </summary>
        /// <returns>async task</returns>
        Task<IList<T>> FindAll();
    }
}
