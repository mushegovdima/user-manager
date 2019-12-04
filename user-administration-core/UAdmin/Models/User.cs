using System.Collections.Generic;

namespace UAdmin.Models
{
    /// <summary>
    /// Класс маппинга пользователя
    /// </summary>
    public class User : Entity
    {
        /// <summary>
        /// ctor
        /// </summary>
        public User()
        {
            Roles = new List<Role>();
        }

        /// <summary>
        /// Логин
        /// </summary>
        public virtual string Login { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// Почта
        /// </summary>
        public virtual string Email { get; set; }

        /// <summary>
        /// Пароль
        /// TODO: шифровать
        /// </summary>
        public virtual string Password { get; set; }
        
        /// <summary>
        /// Список ролей пользователя N-N
        /// </summary>
        public virtual IList<Role> Roles { get; set; }
    }

}
