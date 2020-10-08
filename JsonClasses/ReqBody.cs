using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment1_GetOrderInfoFromNewegg.JsonClasses
{
    public class OrderNumberList
    {
        public List<string> OrderNumber { get; set; }
    }

    public class RequestCriteria
    {
        public OrderNumberList OrderNumberList { get; set; }
    }

    public class RequestBody
    {
        public string PageIndex { get; set; }
        public string PageSize { get; set; }
        public RequestCriteria RequestCriteria { get; set; }
    }

    public class ReqBody
    {
        public string OperationType { get; set; }
        public RequestBody RequestBody { get; set; }
    }
}