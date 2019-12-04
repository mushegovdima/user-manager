using UAdmin.Managers;
using UAdmin.Models;

namespace user_administration_core.Controllers
{
    /// <summary>
    /// Контроллер для <see cref="Role"/>
    /// </summary>
    public class RoleController : EntityController<Role>
    {
        public RoleController(IEntityManager<Role> manager) : base(manager)
        {
        }

    }
}
