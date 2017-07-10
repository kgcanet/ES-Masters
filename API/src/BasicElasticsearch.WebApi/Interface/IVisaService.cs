using BasicElasticsearch.WebApi.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicElasticsearch.WebApi.Interface
{
    public interface IVisaService
    {
        VisaViewModel Get(int id);
        IEnumerable<VisaViewModel> GetByFilter(VisaViewModel dto);
        IEnumerable<VisaViewModel> GetAll();
        VisaViewModel Add(VisaViewModel dto);
        VisaViewModel Update(VisaViewModel dto);
        IEnumerable<VisaViewModel> PutMany(IEnumerable<VisaViewModel> dtos);
        bool Delete(int id);
    }
}
