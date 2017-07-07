using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicElasticsearch.WebApi.Interface
{
    public interface IService<T> where T: class
    {
        T Get(int id);
        IEnumerable<T> GetByFilter(T entity);
        IEnumerable<T> GetAll();
        T Add(T entity);
        T Update(T entity);
        IEnumerable<T> PutMany(IEnumerable<T> entities);
        bool Delete(int id);
    }
}
