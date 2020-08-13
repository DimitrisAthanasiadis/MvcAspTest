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
            currentPage = 1;
            pageSize = 1;

            sortField = "id";
            sortOrder = SortOrder.ASC;
        }

        public int currentPage { get; set; }
        public int totalPages { get; set; }
        public int pageSize { get; set; }
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