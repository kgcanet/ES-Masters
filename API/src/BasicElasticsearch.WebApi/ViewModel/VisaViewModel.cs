using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicElasticsearch.WebApi.ViewModel
{
    public class VisaViewModel
    {
        public string EmployeeVisaID { get; set; }

        public string EmployeeID { get; set; }
        public string VisaPassportNumber { get; set; }
        public string VisaTypeID { get; set; }
        public string VisaStatusID { get; set; }
        public string IsMultipleEntry { get; set; }
        public string IssuanceDate { get; set; }
        public string ExpiryDate { get; set; }
    }
}
