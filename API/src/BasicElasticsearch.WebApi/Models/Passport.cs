using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicElasticsearch.WebApi.Models
{
    [ElasticsearchType(Name = "employee_passport")]
    public class Passport
    {
        [Number(Name = "id")]
        public int Id { get { return this.EmployeePassportID; } }

        [Number(Name = "employee_passport_id")]
        public int EmployeePassportID { get; set; }

        [Number(Name = "employee_id")]
        public int EmployeeID { get; set; }

        [Keyword(Name = "passport_no")]
        public string PassportNumber { get; set; }

        [Date(Name = "issuance_date")]
        public DateTime IssuanceDate { get; set; }

        [Date(Name = "expiry_date")]
        public DateTime ExpiryDate { get; set; }
    }
}
