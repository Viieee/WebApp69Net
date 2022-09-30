using Microsoft.AspNetCore.Mvc;
using WebAppClient.Repositories.Interface;

namespace WebAppClient.Controllers.Base
{
    public class BaseController<Entity, Repository> : Controller
        where Entity : class // entity has to be a class
        where Repository : IGeneralRepository<Entity> // repository has to implement IGeneralRepository interface
    {
        private readonly Repository repository;

        public BaseController(Repository repository)
        {
            this.repository = repository;
        }

        [HttpGet] // /Entity/GetAll
        public JsonResult GetAll()
        {
            var result = repository.Get();
            return Json(result);
        }

        [HttpGet] // /Entity/Get/id
        public JsonResult Get(int id)
        {
            var result = repository.Get(id);
            return Json(result);
        }

        [HttpPost] // /Entity/Post
        public JsonResult Post(Entity entity)
        {
            var result = repository.Post(entity);
            return Json(result);
        }

        [HttpPut] // /Entity/Put/id
        public JsonResult Put(int id, Entity entity)
        {
            var result = repository.Put(id, entity);
            return Json(result);
        }

        [HttpDelete] // /Entity/Delete/id
        public JsonResult Delete(int id)
        {
            var result = repository.Delete(id);
            return Json(result);
        }
    }
}
