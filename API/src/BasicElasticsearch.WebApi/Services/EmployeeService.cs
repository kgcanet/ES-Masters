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
        private Interface.IRepository<Search> _searchRepo;

        public EmployeeService(IMapper mapper, Interface.IRepository<Employee> repo, Interface.IRepository<Search> searchRepo)
        {
            _mapper = mapper;
            _repo = repo;
            _searchRepo = searchRepo;
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

        public IEnumerable<SearchViewModel> PutManySearch(IEnumerable<SearchViewModel> dtos)
        {
            try
            {
                if (dtos.Any())
                {
                    var search = new List<Search>();

                    dtos.ToList().ForEach(entity =>
                    {
                        var model = _mapper.Map<Search>(entity);
                        model.EmployeeNumber = model.EmployeeNumber.Trim();
                        search.Add(model);
                    });

                    _searchRepo.PutMany(search);

                    return dtos;

                }

                throw new ArgumentException("No data to insert");
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public IEnumerable<SearchViewModel> Search(ViewModel.SearchRequest search)
        {
            try
            {
                var viewModels = new List<SearchViewModel>();
                var response = _searchRepo.GetElasticClient().Search<Search>(s => s
                                .MinScore(0.01)
                                .From((search.PageNumber - 1) * search.PageSize)
                                .Size(search.PageSize)
                                .Source(false)
                                .FielddataFields(f =>
                                    f.Fields(
                                        fields => fields.EmployeeID,
                                        fields => fields.EmployeeNumber,
                                        fields => fields.FirstName,
                                        fields => fields.LastName,
                                        fields => fields.EmailAddress,
                                        fields => fields.PositionID,
                                        fields => fields.PositionName,
                                        fields => fields.HireDate,
                                        fields => fields.IsEmployed,
                                        fields => fields.HasPassport,
                                        fields => fields.HasVisa,
                                        fields => fields.IsActive,
                                        fields => fields.EmployeePassportID,
                                        fields => fields.PassportNumber,
                                        fields => fields.IsMultipleEntry,
                                        fields => fields.VisaIssuanceDate,
                                        fields => fields.VisaExpiryDate,
                                        fields => fields.Annotation,
                                        fields => fields.VisaTypeID,
                                        fields => fields.VisaType,
                                        fields => fields.VisaStatusID,
                                        fields => fields.VisaStatus,
                                        fields => fields.EmployeeVisaID,
                                        fields => fields.ExpiryDate,
                                        fields => fields.IssuanceDate,
                                        fields => fields.VisaPassportNumber
                                        )
                                )
                                .Query(q =>
                                {
                                    QueryContainer query = null;
                                    QueryContainer expiringFilter = null;

                                    if (!string.IsNullOrWhiteSpace(search.EmployeeName))
                                    {
                                        //query &= +new TermQuery() { Field = "full_name", Value = search.EmployeeName.ToLower() };
                                        query &= +new MatchPhrasePrefixQuery() { Field = "full_name", Query = search.EmployeeName.ToLower() };
                                    }

                                    if (!string.IsNullOrWhiteSpace(search.EmployeeNumber))
                                    {
                                        //query &= +new TermQuery() { Field = "employee_number", Value = search.EmployeeNumber.ToLower() };
                                        query &= +new MatchPhrasePrefixQuery() { Field = "employee_number", Query = search.EmployeeName.ToLower() };
                                    }

                                    if (search.PostionId != null)
                                    {
                                        query &= +new TermQuery() { Field = "position_id", Value = search.PostionId.ToString() };
                                    }

                                    if (search.ExpiringVisa != null && search.ExpiringVisa == true)
                                    {
                                        query &= +new TermQuery() { Field = "is_expiring_visa", Value = "true" };
                                    }

                                    if (search.ExpiringPassport != null && search.ExpiringPassport == true)
                                    {
                                        query &= +new TermQuery() { Field = "is_expiring_passport", Value = "true" };
                                    }

                                    if (search.NoPassport != null && !search.NoPassport.Value)
                                    {
                                        query &= +new TermQuery() { Field = "has_passport", Value = search.NoPassport.ToString() };
                                    }

                                    if (search.ProcessingVisa != null && search.ProcessingVisa.Value)
                                    {
                                        query &= +new TermQuery() { Field = "position_id", Value = "2" };
                                    }

                                    if (search.WithValidVisaAnnotation != null && search.WithValidVisaAnnotation.Value)
                                    {
                                        query &= +new TermQuery() { Field = "has_visa", Value = "true" };
                                        query &= +new TermQuery() { Field = "position_id", Value = "3" };
                                    }

                                    return query;
                                }));
                                
                                //.Query(q => q
                                //        .Bool(b=>b
                                //                .Must(bs=> bs
                                //                        .Match(m=>m
                                //                                .Field(f=>f.EmployeeNumber)
                                //                                .Query(search.EmployeeNumber)
                                //                        )
                                //                 )
                                //                 .Must(bs => bs
                                //                        .Match(m => m
                                //                                .Field(f => f.FullName)
                                //                                .Query(search.EmployeeName)
                                //                        )
                                //                 )
                                //        )
                                //)
                                

                foreach (IHit<Search> hit in response.Hits)
                {
                    //Models.BasicSearchProfile prof = hit.Source;
                    SearchViewModel searchViewModel = hit.Fields;
                    viewModels.Add(searchViewModel);

                }

                return viewModels;
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
