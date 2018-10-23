using System;
using System.Collections.Generic;
using System.Text;

namespace Drm.Data.Repository
{
    public interface IDrmRepository<T>
    {
        IEnumerable<T> GetAll();
        T Get(int Id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        bool SaveAll();
    }
}
