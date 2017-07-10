using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicElasticsearch.WebApi.Models
{
    [ElasticsearchType(Name = "employee_visa")]
    public class Visa
    {
        [Number(Name = "id")]
        public int Id { get { return this.EmployeeVisaID; } }

        [Number(Name = "employee_visa_id")]
        public int EmployeeVisaID { get; set; }

        [Number(Name = "employee_id")]
        public int EmployeeID { get; set; }

        [Text(Name = "visa_passport_number")]
        public string VisaPassportNumber { get; set; }

        [Number(Name = "visa_type_id")]
        public int VisaTypeID { get; set; }

        [Number(Name = "visa_status_id")]
        public int VisaStatusID { get; set; }

        [Boolean(Name = "is_multiple_entry")]
        public bool IsMultipleEntry { get; set; }

        [Date(Name = "issuance_date")]
        public DateTime IssuanceDate { get; set; }

        [Date(Name = "expiry_date")]
        public DateTime ExpiryDate { get; set; }
    }
}
