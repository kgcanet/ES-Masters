using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using BasicElasticsearch.WebApi.Interface;
using BasicElasticsearch.WebApi.ViewModel;
using System.Net;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace BasicElasticsearch.WebApi.Controllers
{
    [Route("api/reference")]
    public class ReferencesController : Controller
    {
        private IMapper _mapper;
        private IReferenceService _service;

        public ReferencesController(IMapper mapper,IReferenceService service)
        {
            _service = service;
            _mapper = mapper;
        }
        /// <summary>
        /// Get all position
        /// </summary>
        /// <returns></returns>
        [HttpGet("position")]
        [ProducesResponseType(typeof(IEnumerable<PositionViewModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Error), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Error), (int)HttpStatusCode.BadRequest)]
        public IActionResult GetPosition()
        {
            try
            {
                return Ok(_service.GetAllPosition());
            }
            catch (Exception ex)
            {
                //Errors
                var errors = new List<ErrorDetails>();
                errors.Add(new ErrorDetails(Id: "1", Detail: ex.Message) { });


                return BadRequest(new Error(errors));
            }
        }

        /// <summary>
        /// Get all position by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("position/{id}")]
        [ProducesResponseType(typeof(PositionViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Error), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Error), (int)HttpStatusCode.BadRequest)]
        public IActionResult GetPositionById(int id)
        {
            try
            {
                return Ok(_service.GetPosition(id));
            }
            catch (Exception ex)
            {
                //Errors
                var errors = new List<ErrorDetails>();
                errors.Add(new ErrorDetails(Id: "1", Detail: ex.Message) { });


                return BadRequest(new Error(errors));
            }
        }

        /// <summary>
        /// Get all Visa status
        /// </summary>
        /// <returns></returns>
        [HttpGet("visastatus")]
        [ProducesResponseType(typeof(IEnumerable<VisaStatusViewModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Error), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Error), (int)HttpStatusCode.BadRequest)]
        public IActionResult GetVisaStatus()
        {
            try
            {
                return Ok(_service.GetAllVisaStatus());
            }
            catch (Exception ex)
            {
                //Errors
                var errors = new List<ErrorDetails>();
                errors.Add(new ErrorDetails(Id: "1", Detail: ex.Message) { });


                return BadRequest(new Error(errors));
            }
        }

        /// <summary>
        /// Get all visa status by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("visastatus/{id}")]
        [ProducesResponseType(typeof(VisaStatusViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Error), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Error), (int)HttpStatusCode.BadRequest)]
        public IActionResult GetVisaStatusById(int id)
        {
            try
            {
                return Ok(_service.GetVisaStatus(id));
            }
            catch (Exception ex)
            {
                //Errors
                var errors = new List<ErrorDetails>();
                errors.Add(new ErrorDetails(Id: "1", Detail: ex.Message) { });


                return BadRequest(new Error(errors));
            }
        }

        /// <summary>
        /// Get all visa type
        /// </summary>
        /// <returns></returns>
        [HttpGet("visatype")]
        [ProducesResponseType(typeof(IEnumerable<VisaTypeViewModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Error), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Error), (int)HttpStatusCode.BadRequest)]
        public IActionResult GetVisaType()
        {
            try
            {
                return Ok(_service.GetAllVisaType());
            }
            catch (Exception ex)
            {
                //Errors
                var errors = new List<ErrorDetails>();
                errors.Add(new ErrorDetails(Id: "1", Detail: ex.Message) { });


                return BadRequest(new Error(errors));
            }
        }

        /// <summary>
        /// Get visa type by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("visatype/{id}")]
        [ProducesResponseType(typeof(VisaTypeViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Error), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Error), (int)HttpStatusCode.BadRequest)]
        public IActionResult GetVisaTypeById(int id)
        {
            try
            {
                return Ok(_service.GetVisaType(id));
            }
            catch (Exception ex)
            {
                //Errors
                var errors = new List<ErrorDetails>();
                errors.Add(new ErrorDetails(Id: "1", Detail: ex.Message) { });


                return BadRequest(new Error(errors));
            }
        }


        /// <summary>
        /// Put Many Position
        /// </summary>
        /// <param name="positions"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(IEnumerable<PositionViewModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Error), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Error), (int)HttpStatusCode.BadRequest)]
        [HttpPut("bulk/position")]
        public IActionResult PutManyPosition([FromBody]IEnumerable<PositionViewModel> positions)
        {
            try
            {
                _service.PutManyPosition(positions);
                return Ok(positions);
            }
            catch (Exception ex)
            {
                //Errors
                var errors = new List<ErrorDetails>();
                errors.Add(new ErrorDetails(Id: "1", Detail: ex.Message) { });


                return BadRequest(new Error(errors));
            }
        }

        /// <summary>
        /// Put Many Visa Type
        /// </summary>
        /// <param name="visaTypes"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(IEnumerable<VisaTypeViewModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Error), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Error), (int)HttpStatusCode.BadRequest)]
        [HttpPut("bulk/visatype")]
        public IActionResult PutManyVisaType([FromBody]IEnumerable<VisaTypeViewModel> visaTypes)
        {
            try
            {
                _service.PutManyVisaType(visaTypes);
                return Ok(visaTypes);
            }
            catch (Exception ex)
            {
                //Errors
                var errors = new List<ErrorDetails>();
                errors.Add(new ErrorDetails(Id: "1", Detail: ex.Message) { });


                return BadRequest(new Error(errors));
            }
        }


        /// <summary>
        /// Put many visa Status
        /// </summary>
        /// <param name="visaStatuses"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(IEnumerable<VisaStatusViewModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Error), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Error), (int)HttpStatusCode.BadRequest)]
        [HttpPut("bulk/visastatus")]
        public IActionResult PutManyVisaType([FromBody]IEnumerable<VisaStatusViewModel> visaStatuses)
        {
            try
            {
                _service.PutManyVisaStatus(visaStatuses);
                return Ok(visaStatuses);
            }
            catch (Exception ex)
            {
                //Errors
                var errors = new List<ErrorDetails>();
                errors.Add(new ErrorDetails(Id: "1", Detail: ex.Message) { });


                return BadRequest(new Error(errors));
            }
        }

    }
}
