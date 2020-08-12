using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BootstrapIntroduction.Models
{
    public class QueryOptions
    {
        public QueryOptions()
        {
            sortField = "id";
            sortOrder = SortOrder.Ascending;
        }

        public string sortField { get; set; }
        public SortOrder sortOrder { get; set; }

        public string Sort
        {
            get
            {
                return string.Format("{0} {1}",
                    sortField, sortOrder.ToString());
            }
        }
    }
}