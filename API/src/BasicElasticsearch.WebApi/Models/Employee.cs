using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicElasticsearch.WebApi.Models
{
    [ElasticsearchType(Name = "employee_information")]
    public class Employee
    {
        [Number(Name = "id")]
        public int Id { get { return this.EmployeeID; } }

        [Number(Name = "employee_id")]
        public int EmployeeID { get; set; }

        [Text(Name = "employee_number")]
        public string EmployeeNumber { get; set; }

        [Text(Name = "first_name")]
        public string FirstName { get; set; }

        [Text(Name = "last_name")]
        public string LastName { get; set; }

        [Text(Name = "email_address")]
        public string EmailAddress { get; set; }

        [Number(Name = "position_id")]
        public int PositionID { get; set; }

        [Date(Name = "hired_date")]
        public DateTime HireDate { get; set; }

        [Boolean(Name = "is_employed")]
        public bool IsEmployed { get; set; }

        [Boolean(Name = "has_passport")]
        public bool HasPassport { get; set; }

        [Boolean(Name = "has_visa")]
        public bool HasVisa { get; set; }

        [Boolean(Name = "is_active")]
        public bool IsActive { get; set; }

    }
}
