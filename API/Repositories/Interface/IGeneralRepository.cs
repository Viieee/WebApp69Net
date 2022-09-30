using System.Collections.Generic;


namespace API.Repositories.Interface
{
    interface IGeneralRepository<Entity, Primary>
        where Entity : class // entity harus class
    {
        // yang harus diimplementasikan oleh child
        List<Entity> Get();
        Entity Get(Primary id);
        int Post(Entity entity);
        int Put(Primary id, Entity entity);
        int Delete(Primary id);
    }
}
