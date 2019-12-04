using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using UAdmin.Managers;
using UAdmin.Models;

namespace user_administration_core.Controllers
{
    /// <summary>
    /// Абстракция базового контроллера сущности
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Route("api/[controller]")]
    [ApiController]
    public abstract class EntityController<T> : ControllerBase where T : IEntity
    {
        public EntityController(IEntityManager<T> manager)
        {
            this.Manager = manager;
        }

        protected IEntityManager<T> Manager;

        // GET: api/<controller>
        [HttpGet]
        public virtual async Task<IList<T>> Get()
        {
            return await Manager.FindAll();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public virtual T Get(int id)
        {
            return Manager.Load(id);
        }

        // POST api/<controller>
        [HttpPost]
        public virtual void Post([FromBody]T entity)
        {
            Manager.Save(entity);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public virtual void Delete(int id)
        {
            var entity = Manager.Load(id);
            Manager.Delete(entity);
        }
    }
}
