using FluentNHibernate.Mapping;

namespace UAdmin.Models
{
    /// <summary>
    /// Абстрактная реализация сущности
    /// </summary>
    public abstract class Entity : IEntity
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public virtual long Id { get; set; }
    }
    /// <summary>
    /// Базовый класс маппинга сущности
    /// </summary>
    /// <typeparam name="T">Сущность</typeparam>
    public class EntityMap<T> : ClassMap<T> where T : IEntity
    {
        /// <summary>
        /// ctor
        /// </summary>
        public EntityMap()
        {
            Id(x => x.Id);
        }
    }
}
