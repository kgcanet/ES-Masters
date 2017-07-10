using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicElasticsearch.WebApi.Models
{
    [ElasticsearchType(Name = "visa_status")]
    public class VisaStatus
    {
        [Number(Name = "id")]
        public int Id { get { return this.VisaStatusID; } }

        [Number(Name = "visa_status_id")]
        public int VisaStatusID { get; set; }

        [Text(Name = "position_name")]
        public string Status { get; set; }

        [Text(Name = "sort_column")]
        public int SortColumn { get; set; }
    }
}
