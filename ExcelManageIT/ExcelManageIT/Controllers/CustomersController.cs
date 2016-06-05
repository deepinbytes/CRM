using ExcelManageIT.Models;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Kendo.Mvc.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ExcelManageIT.Controllers
{

  

    public class CustomerJson
    {
        [JsonProperty("customer")]
        public IEnumerable<Customer> customer { get; set; }
    }



    public class jsonCustomer
    {
        public string userID;
        public string Password;
        public string companyID;
        public Customer customer;
    }



   


    public class CustomersController : Controller
    {

       

        public Customer customer { get; set; }

     
        [HttpGet]
        public ActionResult CreateCustomers()
        {
            return View();
        }



        [HttpPost]
        public ActionResult CreateCustomers([Bind(Include = "CustomerID,Title,FirstName,MiddleName,LastName,CompanyName,Designation,AddressLine1,AddressLine2,City,State,ZIP,ContactNumber,EmailId,Owner,Source,Status,Description,IsActive,Revenue,CampaignSource,NumberOfOrders,NextStep,MainSource,CreatedDate,CreatedBy")] Customer cust)
        {

            Random rnd = new Random();
            int oID = rnd.Next(1, 1000000);
            cust.CustomerID = oID.ToString();

            //DateTime localDate = DateTime.Now;
            //DateTime dateOnly = localDate.Date;
            //// String contain = ")\\/\"";

            string createdDate = "/Date(" + DateTime.Now.ToString("yyyy-MM-dd") + ")/";
            // string createdDate = "\\/Date(" + dateOnly.ToString() + ")\\/";
            cust.CreatedDate = createdDate;
            cust.CreatedBy = "Varshad";
            var obj = cust;
            var webAddr = "http://localhost:8733/Design_Time_Addresses/ExcelManageITService/Service1/AddCustomer";
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(webAddr);
            httpWebRequest.ContentType = "application/json; charset=utf-8";
            httpWebRequest.Method = "POST";



            var newObj = new jsonCustomer
            {
                userID = "Varshad",
                Password = "password",
                companyID = "Demo",

                customer = obj

            };



            var jsonCust = new JavaScriptSerializer().Serialize(newObj);

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {

                streamWriter.Write(jsonCust);
                streamWriter.Flush();
            }
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                Console.WriteLine("Breaking error");
                Console.WriteLine(streamReader.ReadToEnd());

                return RedirectToAction("CreateCustomers", "Customers");
            }



        }


        //[HttpGet]
        //public ActionResult ViewCustomers()
        //{





        //    //ViewBag.MyList = someObj;



        //    return View();

        //    //var table = JsonConvert.DeserializeObject<DataTable>(res);
        //    //return table;

        //    //IQueryable<Customer> customersList = ;
        //    //DataSourceResult result = customerList.ToDataSourceResult(request);

        //}




        [HttpGet]
        public ActionResult ViewCustomers()
        {


            var newDSObj = new List<Customer>();



            String res = null;
            var webAddr = "http://localhost:8733/Design_Time_Addresses/ExcelManageITService/Service1/ViewCustomer";
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(webAddr);
            httpWebRequest.ContentType = "application/json; charset=utf-8";
            httpWebRequest.Method = "POST";

            var jsonViewCust = new JavaScriptSerializer().Serialize(new
            {
                userID = "Varshad",
                Password = "password",
                companyID = "Demo"

            });

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {

                streamWriter.Write(jsonViewCust);
                streamWriter.Flush();
            }
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {

                res = streamReader.ReadToEnd();



                JObject responseJson = JObject.Parse(res);
                string result = responseJson["ViewCustomerResult"].Value<String>();
                Console.WriteLine(result);


                newDSObj = JsonConvert.DeserializeObject<List<Customer>>(result);



            }
            // IQueryable<Customer> resss = newDSObj.AsQueryable<Customer>();
            // DataSourceResult resss11 = newDSObj.ToDataSourceResult(request);
            //return Json(resss11, JsonRequestBehavior.AllowGet);

            ViewBag.MyList = newDSObj;

            return View();

           

        }









        [HttpGet]
        public JsonResult Customers_Read([DataSourceRequest]DataSourceRequest request)
        {

            var newDSObj = new List<Customer>();



            String res = null;
            var webAddr = "http://localhost:8733/Design_Time_Addresses/ExcelManageITService/Service1/ViewCustomer";
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(webAddr);
            httpWebRequest.ContentType = "application/json; charset=utf-8";
            httpWebRequest.Method = "POST";

            var jsonViewCust = new JavaScriptSerializer().Serialize(new
            {
                userID = "Varshad",
                Password = "password",
                companyID = "Demo"

            });

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {

                streamWriter.Write(jsonViewCust);
                streamWriter.Flush();
            }
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {

                res = streamReader.ReadToEnd();



                JObject responseJson = JObject.Parse(res);
                string result = responseJson["ViewCustomerResult"].Value<String>();
                Console.WriteLine(result);


                newDSObj = JsonConvert.DeserializeObject<List<Customer>>(result);



            }
            // IQueryable<Customer> resss = newDSObj.AsQueryable<Customer>();
            DataSourceResult resss11 = newDSObj.ToDataSourceResult(request);
            return Json(resss11, JsonRequestBehavior.AllowGet);

            // return Json(newDSObj.ToDataSourceResult(request));
        }








    }






}