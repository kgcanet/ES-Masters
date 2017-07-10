using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicElasticsearch.WebApi.Models
{
    [ElasticsearchType(Name = "visa_type")]
    public class VisaType
    {
        [Number(Name = "id")]
        public int Id { get { return this.VisaTypeID; } }

        [Number(Name = "visa_type_id")]
        public int VisaTypeID { get; set; }

        [Text(Name = "visa_type_name")]
        public string VisaTypeName { get; set; }

        [Number(Name = "sort_column")]
        public int SortColumn { get; set; }
    }
}
