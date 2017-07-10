using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicElasticsearch.WebApi.ViewModel
{
    public class SearchViewModel
    {
        public int EmployeeID { get; set; }
        public string EmployeeNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public int PositionID { get; set; }
        public string PositionName { get; set; }
        public string HireDate { get; set; }
        public bool IsEmployed { get; set; }
        public bool HasPassport { get; set; }
        public bool HasVisa { get; set; }
        public bool IsActive { get; set; }
        public int EmployeePassportID { get; set; }
        public string PassportNumber { get; set; }
        public string IssuanceDate { get; set; }
        public string ExpiryDate { get; set; }
        public int EmployeeVisaID { get; set; }
        public string VisaPassportNumber { get; set; }
        public bool IsMultipleEntry { get; set; }
        public string VisaIssuanceDate { get; set; }
        public string VisaExpiryDate { get; set; }
        public string Annotation { get; set; }
        public int VisaTypeID { get; set; }
        public string VisaType { get; set; }
        public int VisaStatusID { get; set; }
        public string VisaStatus { get; set; }
    }
}
