using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicElasticsearch.WebApi.Interface
{
    public interface IRepository<M>
            where M : class
    {

        M Get(int id);
        IEnumerable<M> GetAll();
        bool Add(M entity);
        bool Update(M entity);
        IEnumerable<M> PutMany(IEnumerable<M> entities);
        bool Delete(int id);
    }
}
