using BasicElasticsearch.WebApi.Interface;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicElasticsearch.WebApi.ViewModel
{
    
    public class EmployeeViewModel
    {
        public string EmployeeID { get; set; }

        public string EmployeeNumber { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string EmailAddress { get; set; }

        public string PositionID { get; set; }

        public string HireDate { get; set; }

        public string IsEmployed { get; set; }

        public string HasPassport { get; set; }

        public string HasVisa { get; set; }

        public string IsActive { get; set; }

    }
}
