using System.Collections.Generic;
using System.Data.Entity;
using GameStore.Data.Abstract;

namespace GameStore.Data.Concrete
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly DbContext Context;
        protected DbSet<T> DbSet;//??

        public BaseRepository(DbContext context)
        {
            Context = context;
            DbSet = context.Set<T>();//for why????
        }

        public IEnumerable<T> GetAll()
        {
            return Context.Set<T>();
        }

        public T GetById(int? id)
        {
            //ToDo is null
            //var result = (id) ?? 0;
            //return _context.Set<T>().Find(id);
            return DbSet.Find(id);//??
        }

        public virtual void Create(T entity)
        {
            DbSet.Add(entity);//??
            //_context.Set<T>().Add(entity);

            SaveChanges();
        }

        public virtual void Remove(int id)
        {
            //var entity = _context.Set<T>().Find(id);
            var entity = DbSet.Find(id);

            if (entity == null)
            {
                return;
            }

            if (Context.Entry(entity).State == EntityState.Detached)
            {
                DbSet.Attach(entity);
            }

            DbSet.Remove(entity);

            SaveChanges();
        }

        public virtual void Update(T entity)
        {
            //ToDo check if 2++ is modif!
            DbSet.Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;

            SaveChanges();
        }
        protected void SaveChanges()
        {
            Context.SaveChanges();
        }
    }
}
