using BasicElasticsearch.WebApi.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BasicElasticsearch.WebApi.ViewModel;
using AutoMapper;
using BasicElasticsearch.WebApi.Models;

namespace BasicElasticsearch.WebApi.Services
{
    public class ReferenceService : IReferenceService
    {
        private readonly IMapper _mapper;
        private IRepository<Position> _positionRepo;
        private IRepository<VisaStatus> _visaStatusRepo;
        private IRepository<VisaType> _visaTypeRepo;

        public ReferenceService(IMapper mapper,
                        IRepository<Position> positionRepo,
                        IRepository<VisaStatus> visaStatusRepo,
                        IRepository<VisaType> visaTypeRepo)
        {
            _mapper = mapper;
            _positionRepo = positionRepo;
            _visaStatusRepo = visaStatusRepo;
            _visaTypeRepo = visaTypeRepo;
        }
        public IEnumerable<PositionViewModel> GetAllPosition()
        {
            try
            {
                var models = _positionRepo.GetAll();

                var viewModels = new List<PositionViewModel>();

                models.ToList().ForEach(d =>
                {
                    var viewModel = _mapper.Map<PositionViewModel>(d);
                    viewModels.Add(viewModel);
                });

                return viewModels;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public IEnumerable<VisaStatusViewModel> GetAllVisaStatus()
        {
            try
            {
                var models = _visaStatusRepo.GetAll();

                var viewModels = new List<VisaStatusViewModel>();

                models.ToList().ForEach(d =>
                {
                    var viewModel = _mapper.Map<VisaStatusViewModel>(d);
                    viewModels.Add(viewModel);
                });

                return viewModels;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public IEnumerable<VisaTypeViewModel> GetAllVisaType()
        {
            try
            {
                var models = _visaTypeRepo.GetAll();

                var viewModels = new List<VisaTypeViewModel>();

                models.ToList().ForEach(d =>
                {
                    var viewModel = _mapper.Map<VisaTypeViewModel>(d);
                    viewModels.Add(viewModel);
                });

                return viewModels;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public PositionViewModel GetPosition(int id)
        {
            try
            {
                var model = _positionRepo.Get(id);
                var viewModel = _mapper.Map<PositionViewModel>(model);

                return viewModel;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public VisaStatusViewModel GetVisaStatus(int id)
        {
            try
            {
                var model = _visaStatusRepo.Get(id);
                var viewModel = _mapper.Map<VisaStatusViewModel>(model);

                return viewModel;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public VisaTypeViewModel GetVisaType(int id)
        {
            try
            {
                var model = _visaTypeRepo.Get(id);
                var viewModel = _mapper.Map<VisaTypeViewModel>(model);

                return viewModel;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public IEnumerable<PositionViewModel> PutManyPosition(IEnumerable<PositionViewModel> dtos)
        {
            try
            {
                if (dtos.Any())
                {
                    var positions = new List<Position>();

                    dtos.ToList().ForEach(entity =>
                    {
                        var model = _mapper.Map<Position>(entity);
                        positions.Add(model);
                    });

                    _positionRepo.PutMany(positions);

                    return dtos;

                }

                throw new ArgumentException("No data to insert");
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public IEnumerable<VisaStatusViewModel> PutManyVisaStatus(IEnumerable<VisaStatusViewModel> dtos)
        {
            try
            {
                if (dtos.Any())
                {
                    var visaStatuses = new List<VisaStatus>();

                    dtos.ToList().ForEach(entity =>
                    {
                        var model = _mapper.Map<VisaStatus>(entity);
                        visaStatuses.Add(model);
                    });

                    _visaStatusRepo.PutMany(visaStatuses);

                    return dtos;

                }

                throw new ArgumentException("No data to insert");
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public IEnumerable<VisaTypeViewModel> PutManyVisaType(IEnumerable<VisaTypeViewModel> dtos)
        {
            try
            {
                if (dtos.Any())
                {
                    var visaTypes = new List<VisaType>();

                    dtos.ToList().ForEach(entity =>
                    {
                        var model = _mapper.Map<VisaType>(entity);
                        visaTypes.Add(model);
                    });

                    _visaTypeRepo.PutMany(visaTypes);

                    return dtos;

                }

                throw new ArgumentException("No data to insert");
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
