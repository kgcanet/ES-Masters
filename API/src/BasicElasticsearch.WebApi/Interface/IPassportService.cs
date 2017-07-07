using BasicElasticsearch.WebApi.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicElasticsearch.WebApi.Interface
{
    public interface IPassportService
    {
        PassportViewModel Get(int id);
        IEnumerable<PassportViewModel> GetByFilter(PassportViewModel dto);
        IEnumerable<PassportViewModel> GetAll();
        PassportViewModel Add(PassportViewModel dto);
        PassportViewModel Update(PassportViewModel dto);
        IEnumerable<PassportViewModel> PutMany(IEnumerable<PassportViewModel> dtos);
        bool Delete(int id);
    }
}
