namespace UAdmin.Models
{
    /// <summary>
    /// Интефейс сущности
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        long Id { get; set; }
    }
}