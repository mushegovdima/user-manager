using System.Collections.Generic;

namespace UAdmin.Models
{
    /// <summary>
    /// Роль пользователя
    /// </summary>
    public class Role : Entity
    {
        /// <summary>
        /// ctor
        /// </summary>
        public Role()
        {
            Users = new List<User>();
        }

        /// <summary>
        /// Имя
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// Список польдзователей текущей роли N-N
        /// </summary>
        public virtual IList<User> Users { get; set; }
    }
}
