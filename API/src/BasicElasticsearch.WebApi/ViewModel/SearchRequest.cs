using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicElasticsearch.WebApi.ViewModel
{
    public class SearchRequest
    {
        public SearchRequest()
        {
            this.PageSize = 10;
            this.PageNumber = 1;
        }
        /// <summary>
        /// The page number to return.
        /// </summary>
        public int PageNumber { get; set; }

        /// <summary>
        /// The number of results per page.
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// The value on which to sort
        /// </summary>
        public string SortValue { get; set; }

        /// <summary>
        /// Total number of results
        /// </summary>
        public int Count { get; set; }


        public IEnumerable<SearchViewModel> data { get; set; }


        //filters
        public string EmployeeName { get; set; }

        public string EmployeeNumber { get; set; }

        public int?  PostionId{ get; set; }

        public bool? ExpiringVisa { get; set; }

        public bool? ExpiringPassport { get; set; }

        public bool? NoPassport { get; set; }

        public bool? WithValidVisaAnnotation { get; set; }

        public bool? NoVisa { get; set; }

        public bool? ProcessingVisa { get; set; }
    }
}
