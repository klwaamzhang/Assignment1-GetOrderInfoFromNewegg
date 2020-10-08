using Assignment1_GetOrderInfoFromNewegg.JsonClasses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net;
using System.Text;
using System.Web.UI;

namespace Assignment1_GetOrderInfoFromNewegg
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Create dynymic table
            if (!IsPostBack)
            {
                DataTable dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[5] {
                    new DataColumn("OrderNumber", typeof(string)),
                    new DataColumn("ShipToFirstName",typeof(string)),
                    new DataColumn("ShipToAddress1",typeof(string)),
                    new DataColumn("ShipToZipCode",typeof(string)),
                    new DataColumn("ShipToCountryCode",typeof(string)),
                });

                // request from Canada post api and store the data to the datatable
                dt = PutAPI(dt);

                StringBuilder sb = new StringBuilder();
                sb.Append("<table cellpadding='3' cellspacing='3' style='border: 1px solid #800000;font-size: 12pt;font-family:Arial; margin-top:50px'>");
                //Add Table Header
                sb.Append("<tr>");
                foreach (DataColumn column in dt.Columns)
                {
                    sb.Append("<th style='background-color: #E6E6E6;border: 1px solid #000'>" + column.ColumnName + "</th>");
                }
                sb.Append("</tr>");
                //Add Table Rows
                foreach (DataRow row in dt.Rows)
                {
                    sb.Append("<tr>");
                    //Add Table Columns
                    foreach (DataColumn column in dt.Columns)
                    {
                        sb.Append("<td style='width:300px;border: 1px solid #ccc'>" + row[column.ColumnName].ToString() + "</td>");
                    }
                    sb.Append("</tr>");
                }
                sb.Append("</table>");
                DynamicTable.Text = sb.ToString();
            }

        }
        public DataTable PutAPI(DataTable dt)
        {

            var sellerId = "A006";
            var url = "https://api.newegg.com/marketplace/ordermgmt/order/orderinfo?sellerid=" + sellerId; // REST URL
            string auth = "720ddc067f4d115bd544aff46bc75634";
            string key = "21EC2020-3AEA-1069-A2DD-08002B30309D";
            string dataFormat = "application/json";
            var method = "PUT"; // HTTP Method
            String errorString = "";

            try
            {
                // create request
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                // specify the method
                httpWebRequest.Method = method;
                // add info in header
                httpWebRequest.Headers.Add("Authorization", auth);
                httpWebRequest.Headers.Add("SecretKey", key);
                httpWebRequest.Accept = dataFormat;
                httpWebRequest.ContentType = dataFormat;
                // add request body
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    ReqBody reqBody = new ReqBody();
                    reqBody.OperationType = "GetOrderInfoRequest";
                    reqBody.RequestBody = new RequestBody();
                    reqBody.RequestBody.PageIndex = "1";
                    reqBody.RequestBody.PageSize = "10";
                    reqBody.RequestBody.RequestCriteria = new RequestCriteria();
                    reqBody.RequestBody.RequestCriteria.OrderNumberList = new OrderNumberList();
                    reqBody.RequestBody.RequestCriteria.OrderNumberList.OrderNumber = new List<string>();
                    reqBody.RequestBody.RequestCriteria.OrderNumberList.OrderNumber.Add("159243598");
                    reqBody.RequestBody.RequestCriteria.OrderNumberList.OrderNumber.Add("41473642");
                    reqBody.RequestBody.RequestCriteria.OrderNumberList.OrderNumber.Add("135065400");
                    reqBody.RequestBody.RequestCriteria.OrderNumberList.OrderNumber.Add("287811844");
                    reqBody.RequestBody.RequestCriteria.OrderNumberList.OrderNumber.Add("287811504");

                    string json = JsonConvert.SerializeObject(reqBody);

                    streamWriter.Write(json);
                }

                // get response
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                // read response
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    JsonSerializer jsonSerializer = new JsonSerializer();
                    JsonTextReader reader = new JsonTextReader(streamReader);
                    ResBody resBody = jsonSerializer.Deserialize<ResBody>(reader);

                    foreach (var orderinfo in resBody.ResponseBody.OrderInfoList)
                    {
                        // add the info to table
                        dt.Rows.Add(orderinfo.OrderNumber, orderinfo.ShipToFirstName,orderinfo.ShipToAddress1,orderinfo.ShipToZipCode,orderinfo.ShipToCountryCode);
                    }
                }

            }
            catch (WebException webEx)
            {
                HttpWebResponse response = (HttpWebResponse)webEx.Response;

                if (response != null)
                {
                    errorString += "HTTP  Response Status: " + webEx.Message + "\r\n";

                    try
                    {
                        errorString += "ERROR!!!";
                    }
                    catch (Exception ex)
                    {
                        // Misc Exception
                        errorString += "ERROR: " + ex.Message;
                    }
                }
                else
                {
                    // Invalid Request
                    errorString += "ERROR: " + webEx.Message;
                }

            }
            catch (Exception ex)
            {
                // Misc Exception
                errorString += "ERROR: " + ex.Message;
            }

            errStr.Text = errorString;

            return dt;
        }
    }

    
}