using AutoMapper;
using BasicElasticsearch.WebApi.Interface;
using BasicElasticsearch.WebApi.Models;
using BasicElasticsearch.WebApi.ViewModel;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicElasticsearch.WebApi.Services
{
    /// <summary>
    /// Employee service
    /// </summary>
    public class EmployeeService : IEmployeeService
    {
        private readonly IMapper _mapper;
        private Interface.IRepository<Employee> _repo;

        public EmployeeService(IMapper mapper, Interface.IRepository<Employee> repo)
        {
            _mapper = mapper;
            _repo = repo;
        }
        public EmployeeViewModel Add(EmployeeViewModel dto)
        {
            try
            {
                var model = _mapper.Map<Employee>(dto);

                _repo.Add(model);

                return dto;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public bool Delete(int id)
        {
            try
            {
                return _repo.Delete(id);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public EmployeeViewModel Get(int id)
        {
            try
            {
                var model = _repo.Get(id);
                var viewModel = _mapper.Map<EmployeeViewModel>(model);

                return viewModel;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public IEnumerable<EmployeeViewModel> GetAll()
        {
            try
            {
                var models = _repo.GetAll();

                var viewModels = new List<EmployeeViewModel>();

                models.ToList().ForEach(d =>
                {
                    var viewModel = _mapper.Map<EmployeeViewModel>(d);
                    viewModels.Add(viewModel);
                });

                return viewModels;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public IEnumerable<EmployeeViewModel> GetByFilter(EmployeeViewModel dto)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EmployeeViewModel> PutMany(IEnumerable<EmployeeViewModel> dtos)
        {
            try
            {
                if (dtos.Any())
                {
                    var passports = new List<Employee>();

                    dtos.ToList().ForEach(entity =>
                    {
                        var model = _mapper.Map<Employee>(entity);
                        model.EmployeeNumber = model.EmployeeNumber.Trim();
                        passports.Add(model);
                    });

                    _repo.PutMany(passports);

                    return dtos;

                }

                throw new ArgumentException("No data to insert");
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public EmployeeViewModel Update(EmployeeViewModel dto)
        {
            try
            {
                var model = _mapper.Map<Employee>(dto);

                _repo.Update(model);

                return dto;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
