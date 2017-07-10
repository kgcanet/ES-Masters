using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicElasticsearch.WebApi.Models
{
    [ElasticsearchType(Name = "position")]
    public class Position
    {
        [Number(Name = "id")]
        public int Id { get { return this.PositionID; } }

        [Number(Name = "position_id")]
        public int PositionID { get; set; }

        [Text(Name="position_name")]
        public string PositionName { get; set; }

        [Text(Name = "sort_column")]
        public int SortColumn { get; set; }
    }
}
