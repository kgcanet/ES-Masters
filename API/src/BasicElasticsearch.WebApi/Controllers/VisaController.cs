using AutoMapper;
using BasicElasticsearch.WebApi.Interface;
using BasicElasticsearch.WebApi.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace BasicElasticsearch.WebApi.Controllers
{
    [Route("api/visa")]
    public class VisaController : Controller
    {
        private IVisaService _visaService;
        private readonly IMapper _mapper;
        public VisaController(IMapper mapper, IVisaService _service)
        {
            _mapper = mapper;
            _visaService = _service;
        }
        
        /// <summary>
        /// Get All
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        [ProducesResponseType(typeof(IEnumerable<VisaViewModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Error), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Error), (int)HttpStatusCode.BadRequest)]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_visaService.GetAll());
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
        /// Get Visa by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(VisaViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Error), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Error), (int)HttpStatusCode.BadRequest)]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_visaService.Get(id));
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
        /// Update Visa
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(VisaViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Error), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Error), (int)HttpStatusCode.BadRequest)]
        public IActionResult Update([FromBody]VisaViewModel value)
        {
            try
            {
                return Ok(_visaService.Update(value));
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
        /// Add Visa
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(VisaViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Error), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Error), (int)HttpStatusCode.BadRequest)]
        public IActionResult Post([FromBody]VisaViewModel value)
        {

            try
            {
                return Ok(_visaService.Add(value));
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
        /// Delete Visa by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Error), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Error), (int)HttpStatusCode.BadRequest)]
        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {

            try
            {
                return Ok(_visaService.Delete(id));
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
        /// Put Many
        /// </summary>
        /// <param name="visas"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(IEnumerable<VisaViewModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Error), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Error), (int)HttpStatusCode.BadRequest)]
        [HttpPut("bulk")]
        public IActionResult PutMany([FromBody]IEnumerable<VisaViewModel> visas)
        {
            try
            {
                _visaService.PutMany(visas);
                return Ok(visas);
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
