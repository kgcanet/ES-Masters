using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicElasticsearch.WebApi.ViewModel
{
    public class PositionViewModel
    {
        public string PositionID { get; set; }

        public string PositionName { get; set; }

        public string SortColumn { get; set; }
    }
}
