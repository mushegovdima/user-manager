using UAdmin.Managers;
using UAdmin.Models;

namespace user_administration_core.Controllers
{
    /// <summary>
    /// Контроллер для <see cref="User"/>
    /// </summary>
    public class UserController : EntityController<User>
    {
        public UserController(IEntityManager<User> manager) : base(manager)
        {
        }
    }
}
