using System.Collections.Generic;

namespace GameStore.Data.Abstract
{
    public interface IBaseRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int? id);
        void Create(T entity);
        void Remove(int id);
        void Update(T entityToUpdate);
        
    }
}
