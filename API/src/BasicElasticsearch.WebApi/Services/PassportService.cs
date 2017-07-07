using AutoMapper;
using BasicElasticsearch.WebApi.Interface;
using BasicElasticsearch.WebApi.Models;
using BasicElasticsearch.WebApi.ViewModel;
using Nest;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using BasicElasticsearch.WebApi.Services;
using System.Linq.Expressions;

namespace BasicElasticsearch.WebApi.Services
{
    public class PassportService : IPassportService
    {
        private readonly IMapper _mapper;
        private Interface.IRepository<Passport> _repo;

        /// <summary>
        /// 
        /// </summary>
        public PassportService(IMapper mapper, Interface.IRepository<Passport> repo)
        {
            _mapper = mapper;
            _repo = repo;
            
        }

        public PassportViewModel Add(PassportViewModel dto)
        {
            try
            {
                var model = _mapper.Map<Passport>(dto);

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

        public PassportViewModel Get(int id)
        {
            try
            {
                var model = _repo.Get(id);
                var viewModel = _mapper.Map<PassportViewModel>(model);

                return viewModel;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public IEnumerable<PassportViewModel> GetAll()
        {
            try
            {
                var models = _repo.GetAll();

                var viewModels = new List<PassportViewModel>();

                models.ToList().ForEach(d =>
                {
                    var viewModel = _mapper.Map<PassportViewModel>(d);
                    viewModels.Add(viewModel);
                });

                return viewModels;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }

        }

        public IEnumerable<PassportViewModel> GetByFilter(PassportViewModel dto)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PassportViewModel> PutMany(IEnumerable<PassportViewModel> dtos)
        {
            try
            {
                if (dtos.Any())
                {
                    var passports = new List<Passport>();

                    dtos.ToList().ForEach(entity =>
                    {
                        var model = _mapper.Map<Passport>(entity);
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

        public PassportViewModel Update(PassportViewModel dto)
        {
            try
            {
                var model = _mapper.Map<Passport>(dto);

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
