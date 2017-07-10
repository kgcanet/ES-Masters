using AutoMapper;
using BasicElasticsearch.WebApi.Services;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicElasticsearch.WebApi.Interface
{

    public class Repository<M> : BaseService, IRepository<M> where M : class
    {
        private ElasticClient _esClient { get; set; }
        private readonly IMapper _mapper;

        public Repository(IMapper mapper)
        {
            _esClient = base.CreateElasticClient($"{typeof(M).Name.ToLower()}s-canet-kenneth");
            _mapper = mapper;
        }
        public bool Add(M entity)
        {

            var response = _esClient.Index(entity);

            if (response.IsValid)
            {

                return true;
            }

            throw new ArgumentException("ElasticSearch Error");
        }

        public bool Delete(int id)
        {
            var response = _esClient.Delete<M>(id);

            if (response.IsValid)
            {
                return true;
            }

            throw new ArgumentException("ElasticSearch Error");
        }

        public M Get(int id)
        {
            var response = _esClient.Get<M>(id);

            if (response.IsValid)
            {
                return response.Source;
            }

            throw new ArgumentException("ElasticSearch Error");
        }

        public IEnumerable<M> GetAll()
        {
            try
            {
                var response = _esClient.Search<M>();

                if (response.IsValid)
                {
                    return response.Documents.AsEnumerable();
                }

                throw new ArgumentException("ElasticSearch Error");
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public IEnumerable<M> PutMany(IEnumerable<M> entities)
        {
            if (entities.Any())
            {
                var indexBulk = new BulkRequest();
                //indexBulk.Refresh = true;
                indexBulk.Operations = entities.Select(p => new BulkIndexOperation<M>(p) { }).Cast<IBulkOperation>().ToList();
                var indexResponse = _esClient.Bulk(indexBulk);

                if (indexResponse.IsValid)
                {
                    return entities;
                }

            }

            throw new ArgumentException("ElasticSearch Error");
        }

        public bool Update(M entity)
        {
            var response = _esClient.Index(entity);

            if (response.IsValid)
            {

                return true;
            }

            throw new ArgumentException("ElasticSearch Error");
        }

        public ElasticClient GetElasticClient()
        {
            return _esClient;
        }
    }
}
