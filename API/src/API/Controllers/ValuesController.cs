using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nest;

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<EmployeeInformation> Get()
        {
            var client = new ElasticClient();

            var response = client.Search<EmployeeInformation>(d => d
                    .Index("canet_kenneth_hw3")
                    .Query(q => q.MatchAll()));

            return response.Documents;
        }



    }

    [ElasticsearchType(Name = "employee_information")]
    public class EmployeeInformation
    {
        [Text(Name= "first_name")]
        public string FirstName { get; set; }

        [Text(Name = "last_name")]
        public string LastName { get; set; }

        [Text(Name = "full_name")]
        public string FullName { get; set; }

        [Text(Name = "position")]
        public string Position { get; set; }

        [Text(Name = "age")]
        public int Age { get; set; }

        [Text(Name = "is_active")]
        public bool IsActive { get; set; }
    }
}
