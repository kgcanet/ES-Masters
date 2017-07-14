using BasicElasticsearch.WebApi.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicElasticsearch.WebApi.Interface
{
    public interface IEmployeeService
    {
        EmployeeViewModel Get(int id);
        IEnumerable<EmployeeViewModel> GetByFilter(EmployeeViewModel dto);
        IEnumerable<EmployeeViewModel> GetAll();
        EmployeeViewModel Add(EmployeeViewModel dto);
        EmployeeViewModel Update(EmployeeViewModel dto);
        IEnumerable<EmployeeViewModel> PutMany(IEnumerable<EmployeeViewModel> dtos);
        bool Delete(int id);


        IEnumerable<SearchViewModel> PutManySearch(IEnumerable<SearchViewModel> dtos);
        IEnumerable<SearchViewModel> Search(SearchRequest search);
    }
}
