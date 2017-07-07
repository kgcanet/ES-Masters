using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace BasicElasticsearch.WebApi.Controllers
{
    [Route("api/reference")]
    public class ReferencesController : Controller
    {       
        /// <summary>
        /// Get all position
        /// </summary>
        /// <returns></returns>
        [HttpGet("position")]
        public IEnumerable<string> GetPosition()
        {
            return new string[] { "value1", "value2" };
        }

        /// <summary>
        /// Get all position by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("position/{id}")]
        public string GetPositionById(int id)
        {
            return "value";
        }

        /// <summary>
        /// Get all Visa status
        /// </summary>
        /// <returns></returns>
        [HttpGet("visastatus")]
        public IEnumerable<string> GetVisaStatus()
        {
            return new string[] { "value1", "value2" };
        }

        /// <summary>
        /// Get all visa status by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("visastatus/{id}")]
        public string GetVisaStatusByIdt(int id)
        {
            return "value";
        }

        /// <summary>
        /// Get all visa type
        /// </summary>
        /// <returns></returns>
        [HttpGet("visatype")]
        public IEnumerable<string> GetVisaType()
        {
            return new string[] { "value1", "value2" };
        }

        /// <summary>
        /// Get visa type by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("visatype/{id}")]
        public string GetVisaTypeById(int id)
        {
            return "value";
        }
    }
}
