using Nest;
using Newtonsoft.Json;
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



        public static implicit operator SearchViewModel(FieldValues search)
        {
            return new SearchViewModel()
            {
                EmployeeID = search.Any() ? (JsonConvert.DeserializeObject((search.Where(_ => _.Key == "employee_id").FirstOrDefault().Value != null) ? search.Where(_ => _.Key == "employee_id").FirstOrDefault().Value.ToString() : "[\"\"]") as dynamic)[0] : 0,
                EmployeeNumber = search.Any() ? (JsonConvert.DeserializeObject((search.Where(_ => _.Key == "employee_number").FirstOrDefault().Value != null) ? search.Where(_ => _.Key == "employee_number").FirstOrDefault().Value.ToString() : "[\"\"]") as dynamic)[0] : 0,
                FirstName = search.Any() ? (JsonConvert.DeserializeObject((search.Where(_ => _.Key == "first_name").FirstOrDefault().Value != null) ? search.Where(_ => _.Key == "first_name").FirstOrDefault().Value.ToString() : "[\"\"]") as dynamic)[0] : 0,
                LastName = search.Any() ? (JsonConvert.DeserializeObject((search.Where(_ => _.Key == "last_name").FirstOrDefault().Value != null) ? search.Where(_ => _.Key == "last_name").FirstOrDefault().Value.ToString() : "[\"\"]") as dynamic)[0] : 0,
                EmailAddress = search.Any() ? (JsonConvert.DeserializeObject((search.Where(_ => _.Key == "email_address").FirstOrDefault().Value != null) ? search.Where(_ => _.Key == "email_address").FirstOrDefault().Value.ToString() : "[\"\"]") as dynamic)[0] : 0,
                PositionID = search.Any() ? (JsonConvert.DeserializeObject((search.Where(_ => _.Key == "position_id").FirstOrDefault().Value != null) ? search.Where(_ => _.Key == "position_id").FirstOrDefault().Value.ToString() : "[\"\"]") as dynamic)[0] : 0,
                PositionName = search.Any() ? (JsonConvert.DeserializeObject((search.Where(_ => _.Key == "position_name").FirstOrDefault().Value != null) ? search.Where(_ => _.Key == "position_name").FirstOrDefault().Value.ToString() : "[\"\"]") as dynamic)[0] : 0,
                HireDate = search.Any() ? (JsonConvert.DeserializeObject((search.Where(_ => _.Key == "hired_date").FirstOrDefault().Value != null) ? search.Where(_ => _.Key == "hired_date").FirstOrDefault().Value.ToString() : "[\"\"]") as dynamic)[0] : 0,
                IsEmployed = search.Any() ? (JsonConvert.DeserializeObject((search.Where(_ => _.Key == "is_employed").FirstOrDefault().Value != null) ? search.Where(_ => _.Key == "is_employed").FirstOrDefault().Value.ToString() : "[\"\"]") as dynamic)[0] : 0,
                HasPassport = search.Any() ? (JsonConvert.DeserializeObject((search.Where(_ => _.Key == "has_passport").FirstOrDefault().Value != null) ? search.Where(_ => _.Key == "has_passport").FirstOrDefault().Value.ToString() : "[\"\"]") as dynamic)[0] : 0,
                HasVisa = search.Any() ? (JsonConvert.DeserializeObject((search.Where(_ => _.Key == "has_visa").FirstOrDefault().Value != null) ? search.Where(_ => _.Key == "has_visa").FirstOrDefault().Value.ToString() : "[\"\"]") as dynamic)[0] : 0,
                IsActive = search.Any() ? (JsonConvert.DeserializeObject((search.Where(_ => _.Key == "is_active").FirstOrDefault().Value != null) ? search.Where(_ => _.Key == "is_active").FirstOrDefault().Value.ToString() : "[\"\"]") as dynamic)[0] : 0,
                EmployeePassportID = search.Any() ? (JsonConvert.DeserializeObject((search.Where(_ => _.Key == "employee_passport_id").FirstOrDefault().Value != null) ? search.Where(_ => _.Key == "employee_passport_id").FirstOrDefault().Value.ToString() : "[\"\"]") as dynamic)[0] : 0,
                PassportNumber = search.Any() ? (JsonConvert.DeserializeObject((search.Where(_ => _.Key == "passport_number").FirstOrDefault().Value != null) ? search.Where(_ => _.Key == "passport_number").FirstOrDefault().Value.ToString() : "[\"\"]") as dynamic)[0] : 0,
                IsMultipleEntry = search.Any() ? (JsonConvert.DeserializeObject((search.Where(_ => _.Key == "is_multiple_entry").FirstOrDefault().Value != null) ? search.Where(_ => _.Key == "is_multiple_entry").FirstOrDefault().Value.ToString() : "[\"\"]") as dynamic)[0] : 0,
                VisaIssuanceDate = search.Any() ? (JsonConvert.DeserializeObject((search.Where(_ => _.Key == "visa_issuance_date").FirstOrDefault().Value != null) ? search.Where(_ => _.Key == "visa_issuance_date").FirstOrDefault().Value.ToString() : "[\"\"]") as dynamic)[0] : 0,
                VisaExpiryDate = search.Any() ? (JsonConvert.DeserializeObject((search.Where(_ => _.Key == "visa_expiry_date").FirstOrDefault().Value != null) ? search.Where(_ => _.Key == "visa_expiry_date").FirstOrDefault().Value.ToString() : "[\"\"]") as dynamic)[0] : 0,
                Annotation = search.Any() ? (JsonConvert.DeserializeObject((search.Where(_ => _.Key == "annotation").FirstOrDefault().Value != null) ? search.Where(_ => _.Key == "annotation").FirstOrDefault().Value.ToString() : "[\"\"]") as dynamic)[0] : 0,
                VisaTypeID = search.Any() ? (JsonConvert.DeserializeObject((search.Where(_ => _.Key == "visa_type_id").FirstOrDefault().Value != null) ? search.Where(_ => _.Key == "visa_type_id").FirstOrDefault().Value.ToString() : "[\"\"]") as dynamic)[0] : 0,
                VisaType = search.Any() ? (JsonConvert.DeserializeObject((search.Where(_ => _.Key == "visa_type").FirstOrDefault().Value != null) ? search.Where(_ => _.Key == "visa_type").FirstOrDefault().Value.ToString() : "[\"\"]") as dynamic)[0] : 0,
                VisaStatusID = search.Any() ? (JsonConvert.DeserializeObject((search.Where(_ => _.Key == "visa_status_id").FirstOrDefault().Value != null) ? search.Where(_ => _.Key == "visa_status_id").FirstOrDefault().Value.ToString() : "[\"\"]") as dynamic)[0] : 0,
                VisaStatus = search.Any() ? (JsonConvert.DeserializeObject((search.Where(_ => _.Key == "visa_status").FirstOrDefault().Value != null) ? search.Where(_ => _.Key == "visa_status").FirstOrDefault().Value.ToString() : "[\"\"]") as dynamic)[0] : 0,
                EmployeeVisaID = search.Any() ? (JsonConvert.DeserializeObject((search.Where(_ => _.Key == "emoplyee_visa_id").FirstOrDefault().Value != null) ? search.Where(_ => _.Key == "emoplyee_visa_id").FirstOrDefault().Value.ToString() : "[\"\"]") as dynamic)[0] : 0,
                ExpiryDate = search.Any() ? (JsonConvert.DeserializeObject((search.Where(_ => _.Key == "expiry_date").FirstOrDefault().Value != null) ? search.Where(_ => _.Key == "expiry_date").FirstOrDefault().Value.ToString() : "[\"\"]") as dynamic)[0] : 0,
                IssuanceDate = search.Any() ? (JsonConvert.DeserializeObject((search.Where(_ => _.Key == "issuance_date").FirstOrDefault().Value != null) ? search.Where(_ => _.Key == "issuance_date").FirstOrDefault().Value.ToString() : "[\"\"]") as dynamic)[0] : 0,
                VisaPassportNumber = search.Any() ? (JsonConvert.DeserializeObject((search.Where(_ => _.Key == "visa_passport_number").FirstOrDefault().Value != null) ? search.Where(_ => _.Key == "visa_passport_number").FirstOrDefault().Value.ToString() : "[\"\"]") as dynamic)[0] : 0

            };
        }
    }
}
