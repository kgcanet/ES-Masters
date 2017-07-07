using Nest;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicElasticsearch.WebApi.ViewModel
{
    public class PassportViewModel
    {
        public string EmployeePassportID { get; set; }
        public string EmployeeID { get; set; }
        public string PassportNumber { get; set; }
        public string IssuanceDate { get; set; }
        public string ExpiryDate { get; set; }


        public static implicit operator PassportViewModel(FieldValues passport)
        {
            return new PassportViewModel()
            {
                EmployeePassportID = passport.Any() ? (JsonConvert.DeserializeObject((passport.Where(_ => _.Key == "employee_passport_id").FirstOrDefault().Value != null) ? passport.Where(_ => _.Key == "employee_passport_id").FirstOrDefault().Value.ToString() : "[\"\"]") as dynamic)[0] : 0,
                PassportNumber = passport.Any() ? (JsonConvert.DeserializeObject((passport.Where(_ => _.Key == "passport_no").FirstOrDefault().Value != null) ? passport.Where(_ => _.Key == "passport_no").FirstOrDefault().Value.ToString() : "[\"\"]") as dynamic)[0] : 0,
                IssuanceDate = passport.Any() ? (JsonConvert.DeserializeObject((passport.Where(_ => _.Key == "issuance_date").FirstOrDefault().Value != null) ? passport.Where(_ => _.Key == "issuance_date").FirstOrDefault().Value.ToString() : "[\"\"]") as dynamic)[0] : 0,
                ExpiryDate = passport.Any() ? (JsonConvert.DeserializeObject((passport.Where(_ => _.Key == "expiry_date").FirstOrDefault().Value != null) ? passport.Where(_ => _.Key == "expiry_date").FirstOrDefault().Value.ToString() : "[\"\"]") as dynamic)[0] : 0,
            };
        }
    }
}
