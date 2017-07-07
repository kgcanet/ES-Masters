using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace BasicElasticsearch.WebApi.Controllers
{
    [Route("api/visa")]
    public class VisaController : Controller
    {
        /// <summary>
        /// Get all visa details
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        public IActionResult Get()
        {
            return new OkResult();
        }

        /// <summary>
        /// Get visa detail by id
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return new OkResult();
        }

        /// <summary>
        /// Update existing visa details
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Put([FromBody]object value)
        {
            return new OkResult();
        }

        /// <summary>
        /// Add visa details
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody]object value)
        {
            return new OkResult();
        }

        /// <summary>
        /// Delete visa detail
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return new OkResult();
        }
    }
}
