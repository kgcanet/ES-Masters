using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicElasticsearch.WebApi.Models
{
    [ElasticsearchType(Name = "search")]
    public class Search
    {
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

        [Text(Name = "position_name")]
        public string PositionName { get; set; }

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

        [Number(Name = "employee_passport_id")]
        public int EmployeePassportID { get; set; }

        [Text(Name = "passport_number")]
        public string PassportNumber { get; set; }

        [Date(Name = "issuance_date")]
        public DateTime IssuanceDate { get; set; }

        [Date(Name = "expiry_date")]
        public DateTime ExpiryDate { get; set; }

        [Boolean(Name = "is_expiring_passport")]
        public bool IsExpiringPassport
        {
            get {
                if(!this.ExpiryDate.Equals(DateTime.MinValue) && this.ExpiryDate.AddMonths(-7) > DateTime.Now)
                {
                    return true;
                }
                return false;
            }
        }

        [Number(Name = "emoplyee_visa_id")]
        public int EmployeeVisaID { get; set; }

        [Text(Name = "visa_passport_number")]
        public string VisaPassportNumber { get; set; }

        [Boolean(Name = "is_multiple_entry")]
        public bool IsMultipleEntry { get; set; }

        [Date(Name = "visa_issuance_date")]
        public DateTime VisaIssuanceDate { get; set; }

        [Date(Name = "visa_expiry_date")]
        public DateTime VisaExpiryDate { get; set; }

        [Boolean(Name = "is_expiring_visa")]
        public bool IsExpiringVisa
        {
            get
            {
                if (!this.VisaExpiryDate.Equals(DateTime.MinValue) && this.VisaExpiryDate.AddMonths(-1) > DateTime.Now)
                {
                    return true;
                }
                return false;
            }
        }

        [Text(Name = "annotation")]
        public string Annotation { get; set; }

        [Number(Name = "visa_type_id")]
        public int VisaTypeID { get; set; }

        [Text(Name = "visa_type")]
        public string VisaType { get; set; }

        [Number(Name = "visa_status_id")]
        public int VisaStatusID { get; set; }

        [Text(Name = "visa_status")]
        public string VisaStatus { get; set; }

        [Text(Name = "full_name",Analyzer ="fullname_analyzer")]
        public string FullName { get { return $"{this.FirstName} {this.LastName}"; } }
    }
}
