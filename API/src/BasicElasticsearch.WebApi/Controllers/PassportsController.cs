using AutoMapper;
using BasicElasticsearch.WebApi.Services;
using BasicElasticsearch.WebApi.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Linq;
using System.Collections.Generic;
using System;
using BasicElasticsearch.WebApi.Models;
using BasicElasticsearch.WebApi.Interface;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace BasicElasticsearch.WebApi.Controllers
{
    [Route("api/passport")]
    public class PassportsController : Controller
    {
        private IPassportService _passportService;
        private readonly IMapper _mapper;

        public PassportsController(IMapper mapper, IPassportService _service)
        {
            _passportService = _service;
            _mapper = mapper;
        }
        /// <summary>
        /// Get all passport details
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        [ProducesResponseType(typeof(IEnumerable<PassportViewModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Error), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Error), (int)HttpStatusCode.BadRequest)]
        public IActionResult Get()
        {
            try
            {
                return Ok(_passportService.GetAll());
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
        /// Get passport detail by id
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PassportViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Error), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Error), (int)HttpStatusCode.BadRequest)]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_passportService.Get(id));
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
        /// Update existing passport details
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(PassportViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Error), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Error), (int)HttpStatusCode.BadRequest)]
        public IActionResult Put([FromBody]PassportViewModel value)
        {
            try
            {
                return Ok(_passportService.Update(value));
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
        /// Add passport details
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(PassportViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Error), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Error), (int)HttpStatusCode.BadRequest)]
        public IActionResult Post([FromBody]PassportViewModel value)
        {
            try
            {
                return Ok(_passportService.Add(value));
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
        /// Delete Passport detail
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Error), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Error), (int)HttpStatusCode.BadRequest)]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                return Ok(_passportService.Delete(id));
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
        /// <param name="passports"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(IEnumerable<PassportViewModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Error), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Error), (int)HttpStatusCode.BadRequest)]
        [HttpPut("bulk")]
        [Obsolete]
        public IActionResult PutMany([FromBody]IEnumerable<PassportViewModel> passports)
        {
            try
            {
                _passportService.PutMany(passports);
                return Ok(passports);
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
