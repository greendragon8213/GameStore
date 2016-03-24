using System.Collections.Generic;
using System.Data.Entity;
using GameStore.Data.Abstract;

namespace GameStore.Data.Concrete
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly GameStoreDbContext _context;

        public BaseRepository(GameStoreDbContext dataContext)
        {
            _context = dataContext;
        }

        public BaseRepository()
        {
            _context = new GameStoreDbContext();
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id); 
        }

        public virtual void Create(T entity)
        {
            _context.Set<T>().Add(entity);
            SaveChanges();
        }

        public virtual void Remove(int id)
        {
            var entity = _context.Set<T>().Find(id);

            if (entity == null)
            {
                return;
            }

            _context.Set<T>().Remove(entity);
            SaveChanges();
        }

        protected void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
