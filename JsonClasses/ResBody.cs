using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment1_GetOrderInfoFromNewegg.JsonClasses
{

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class PageInfo
    {
        public int TotalCount { get; set; }
        public int TotalPageCount { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }

    public class ItemInfoList
    {
        public string SellerPartNumber { get; set; }
        public string NeweggItemNumber { get; set; }
        public string MfrPartNumber { get; set; }
        public string UPCCode { get; set; }
        public string Description { get; set; }
        public int OrderedQty { get; set; }
        public int ShippedQty { get; set; }
        public double UnitPrice { get; set; }
        public double ExtendUnitPrice { get; set; }
        public double ExtendShippingCharge { get; set; }
        public int Status { get; set; }
        public string StatusDescription { get; set; }
    }

    public class ItemInfoList2
    {
        public string SellerPartNumber { get; set; }
        public string MfrPartNumber { get; set; }
        public int ShippedQty { get; set; }
    }

    public class PackageInfoList
    {
        public string PackageType { get; set; }
        public string ShipCarrier { get; set; }
        public string ShipService { get; set; }
        public string TrackingNumber { get; set; }
        public string ShipDate { get; set; }
        public List<ItemInfoList2> ItemInfoList { get; set; }
    }

    public class OrderInfoList
    {
        public string SellerID { get; set; }
        public int OrderNumber { get; set; }
        public int InvoiceNumber { get; set; }
        public bool OrderDownloaded { get; set; }
        public string OrderDate { get; set; }
        public int OrderStatus { get; set; }
        public string OrderStatusDescription { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhoneNumber { get; set; }
        public string CustomerEmailAddress { get; set; }
        public string ShipToAddress1 { get; set; }
        public string ShipToAddress2 { get; set; }
        public string ShipToCityName { get; set; }
        public string ShipToStateCode { get; set; }
        public string ShipToZipCode { get; set; }
        public string ShipToCountryCode { get; set; }
        public string ShipService { get; set; }
        public string ShipToFirstName { get; set; }
        public string ShipToLastName { get; set; }
        public string ShipToCompany { get; set; }
        public double OrderItemAmount { get; set; }
        public double ShippingAmount { get; set; }
        public double DiscountAmount { get; set; }
        public double RefundAmount { get; set; }
        public double OrderTotalAmount { get; set; }
        public int OrderQty { get; set; }
        public bool IsAutoVoid { get; set; }
        public List<ItemInfoList> ItemInfoList { get; set; }
        public List<PackageInfoList> PackageInfoList { get; set; }
    }

    public class ResponseBody
    {
        public PageInfo PageInfo { get; set; }
        public List<OrderInfoList> OrderInfoList { get; set; }
    }

    public class ResBody
    {
        public string ResponseDate { get; set; }
        public string Memo { get; set; }
        public bool IsSuccess { get; set; }
        public string OperationType { get; set; }
        public string SellerID { get; set; }
        public ResponseBody ResponseBody { get; set; }
    }


}