using BasicElasticsearch.WebApi.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BasicElasticsearch.WebApi.ViewModel;
using BasicElasticsearch.WebApi.Models;
using AutoMapper;

namespace BasicElasticsearch.WebApi.Services
{
    public class VisaService : IVisaService
    {
        private readonly IMapper _mapper;
        private Interface.IRepository<Visa> _repo;

        public VisaService(IMapper mapper, Interface.IRepository<Visa> repo)
        {
            _mapper = mapper;
            _repo = repo;
        }
        public VisaViewModel Add(VisaViewModel dto)
        {
            try
            {
                var model = _mapper.Map<Visa>(dto);

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

        public VisaViewModel Get(int id)
        {
            try
            {
                var model = _repo.Get(id);
                var viewModel = _mapper.Map<VisaViewModel>(model);

                return viewModel;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public IEnumerable<VisaViewModel> GetAll()
        {
            try
            {
                var models = _repo.GetAll();

                var viewModels = new List<VisaViewModel>();

                models.ToList().ForEach(d =>
                {
                    var viewModel = _mapper.Map<VisaViewModel>(d);
                    viewModels.Add(viewModel);
                });

                return viewModels;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public IEnumerable<VisaViewModel> GetByFilter(VisaViewModel dto)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<VisaViewModel> PutMany(IEnumerable<VisaViewModel> dtos)
        {
            try
            {
                if (dtos.Any())
                {
                    var passports = new List<Visa>();

                    dtos.ToList().ForEach(entity =>
                    {
                        var model = _mapper.Map<Visa>(entity);
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

        public VisaViewModel Update(VisaViewModel dto)
        {
            try
            {
                var model = _mapper.Map<Visa>(dto);

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
