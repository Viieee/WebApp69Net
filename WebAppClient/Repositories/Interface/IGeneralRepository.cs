using System.Collections.Generic;
using System.Net;

namespace WebAppClient.Repositories.Interface
{
    public interface IGeneralRepository<Entity>
        where Entity : class
    {
        List<Entity> Get();
        Entity Get(int id);
        HttpStatusCode Post(Entity entity);
        HttpStatusCode Put(int id, Entity entity);
        HttpStatusCode Delete(int id);
    }
}
