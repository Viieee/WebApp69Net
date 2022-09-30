using API.Context;
using API.Repositories.Interface;
using System.Collections.Generic;
using System.Linq;

namespace API.Repositories
{
    public class GeneralRepository<Entity, Primary> : IGeneralRepository<Entity, Primary>
        where Entity : class
    {
        MyContext myContext; // general repo membutuhkan context untuk berjalan
        public GeneralRepository(MyContext myContext)
        {
            this.myContext = myContext;
        }
        // implementasikan semua yang ada di interface
        // get all
        public List<Entity> Get()
        {
            var data = myContext.Set<Entity>().ToList();
            return data;
        }
        // get by id 
        public Entity Get(Primary id)
        {
            var data = myContext.Set<Entity>().Find(id);
            return data;
        }
        // post
        public int Post(Entity entity)
        {
            myContext.Set<Entity>().Add(entity);
            int result = myContext.SaveChanges();
            return result;
        }
        // edit
        public int Put(Primary id, Entity entity)
        {
            var data = myContext.Set<Entity>().Find(id);
            //myContext.Entry(entity).State = EntityState.Modified;
            myContext.Entry(data).CurrentValues.SetValues(entity);
            int result = myContext.SaveChanges();
            return result;
        }
        // delete
        public int Delete(Primary id)
        {
            var data = Get(id);
            myContext.Set<Entity>().Remove(data);
            int result = myContext.SaveChanges();
            return result;
        }
    }
}
