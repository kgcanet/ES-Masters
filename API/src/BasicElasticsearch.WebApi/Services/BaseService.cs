using BasicElasticsearch.WebApi.Interface;
using Nest;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace BasicElasticsearch.WebApi.Services
{
    /// <summary>
    /// Base Service
    /// </summary>
    public class BaseService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        protected ElasticClient CreateElasticClient(string index = "employees-canet-kenneth")
        {
            Uri node = new Uri("http://10.155.64.92:9200");
            ConnectionSettings settings = new ConnectionSettings(node)
                .DefaultIndex(index);

            /////////////////////////////////////////////////////
            //// Uncomment for debugging purpose
            /////////////////////////////////////////////////////

            //.DisableDirectStreaming()
            //.OnRequestCompleted(details =>
            //{
            //    Debug.WriteLine("### ES REQEUST ###");
            //    if (details.RequestBodyInBytes != null) Debug.WriteLine(Encoding.UTF8.GetString(details.RequestBodyInBytes));
            //    Debug.WriteLine("### ES RESPONSE ###");
            //    if (details.ResponseBodyInBytes != null) Debug.WriteLine(Encoding.UTF8.GetString(details.ResponseBodyInBytes));
            //})
            //.PrettyJson();


            return new ElasticClient(settings);
        }
    }
}
