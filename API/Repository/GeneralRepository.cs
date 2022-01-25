using API.Context;
using API.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository
{
    public class GeneralRepository<Context, Entity, Key> : IRepository<Entity, Key> 
        where Entity : class 
        where Context : MyContext
    {
        private readonly MyContext myContext;
        private readonly DbSet<Entity> entities;

        public GeneralRepository(MyContext myContext)
        {
            this.myContext = myContext;
            this.entities = myContext.Set<Entity>();
        }

        public int Delete(Key key)
        {

            var entity = entities.Find(key);
            entities.Remove(entity);
            if (entity == null) 
                throw new ArgumentNullException("entity");
            var respond = myContext.SaveChanges();
            return respond;

        }

        public IEnumerable<Entity> Get()
        {
            return entities.ToList();
        }

        public Entity Get(Key key)
        {
            return entities.Find(key);
        }

        public int Insert(Entity entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");
                entities.Add(entity);
                return myContext.SaveChanges();
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int Update(Entity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");
            myContext.Entry(entity).State = EntityState.Modified;
            return myContext.SaveChanges();
        }
    }
}
