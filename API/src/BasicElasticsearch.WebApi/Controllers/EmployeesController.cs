using Microsoft.AspNetCore.Mvc;
using BasicElasticsearch.WebApi.ViewModel;
using System.Net;
using System.Collections.Generic;
using System;
using BasicElasticsearch.WebApi.Services;
using System.Linq;
using AutoMapper;
using BasicElasticsearch.WebApi.Models;
using BasicElasticsearch.WebApi.Interface;

namespace BasicElasticsearch.WebApi.Controllers
{
    [Route("api/employee")]
    public class EmployeesController : Controller
    {
        private IEmployeeService _employeeService;
        private readonly IMapper _mapper;
        public EmployeesController(IMapper mapper, IEmployeeService _service)
        {
            _mapper = mapper;
            _employeeService = _service;
        }
        /// <summary>
        /// Search employee by filters
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpGet("search")]
        [ProducesResponseType(typeof(SearchViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Error), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Error), (int)HttpStatusCode.BadRequest)]
        public IActionResult Search([FromBody]string value)
        {
            return new OkResult();
        }

        /// <summary>
        /// Search employee by filters
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPut("search/bulk")]
        [ProducesResponseType(typeof(SearchViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Error), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Error), (int)HttpStatusCode.BadRequest)]
        public IActionResult SearchBulk([FromBody]IEnumerable<EmployeeViewModel> test)
        {
            return new OkResult();
        }

        /// <summary>
        /// Get Employee by ID
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        [HttpGet("getemployeebyid/{employeeId}")]
        [ProducesResponseType(typeof(EmployeeViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Error), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Error), (int)HttpStatusCode.BadRequest)]
        public IActionResult GetEmployeeById(int employeeId)
        {
            try
            {
                return Ok(_employeeService.Get(employeeId));
            }
            catch (Exception ex)
            {
                //Errors
                var errors = new List<ErrorDetails>();
                errors.Add(new ErrorDetails(Id: "1",Detail: ex.Message) { });


                return BadRequest(new Error(errors));
            }
        }

        /// <summary>
        /// Update Employee
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(EmployeeViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Error), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Error), (int)HttpStatusCode.BadRequest)]
        public IActionResult UpdateEmployee([FromBody]EmployeeViewModel value)
        {
            try
            {
                return Ok(_employeeService.Update(value));
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
        /// Add Employee
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(EmployeeViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Error), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Error), (int)HttpStatusCode.BadRequest)]
        public IActionResult Post([FromBody]EmployeeViewModel value)
        {
            
            try
            {
                return Ok(_employeeService.Add(value));
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
        /// Delete Employee
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Error), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Error), (int)HttpStatusCode.BadRequest)]
        [HttpDelete("{employeeId}")]
        public IActionResult DeleteEmployee(int employeeId)
        {
            
            try
            {
                return Ok(_employeeService.Delete(employeeId));
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
        /// <param name="employes"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(IEnumerable<EmployeeViewModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Error), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Error), (int)HttpStatusCode.BadRequest)]
        [HttpPut("bulk")]
        public IActionResult PutMany([FromBody]IEnumerable<EmployeeViewModel> employes)
        {
            try
            {
                _employeeService.PutMany(employes);
                return Ok(employes);
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
