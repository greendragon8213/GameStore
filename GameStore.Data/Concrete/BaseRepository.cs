using System.Collections.Generic;
using System.Data.Entity;
using GameStore.Data.Abstract;

namespace GameStore.Data.Concrete
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        public DbSet<T> DataTable;
        private readonly GameStoreDbContext _context;

        public BaseRepository(GameStoreDbContext dataContext)
        {
            _context = dataContext;
            DataTable = dataContext.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return DataTable;
        }

        public T GetById(int id)
        {
            return DataTable.Find(id);
        }

        public virtual void Create(T entity)
        {
            DataTable.Add(entity);
            SaveChanges();
        }

        public virtual void Remove(int id)
        {
            var entity = DataTable.Find(id);

            if (entity == null)
            {
                return;
            }

            DataTable.Remove(entity);
            SaveChanges();
        }

        protected void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
