using ExcelManageIT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Runtime.Serialization.Json;

using System.Web.Script.Serialization;
using System.Net;
using System.IO;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace ExcelManageIT.Controllers
{
    public class jsonLead
    {
        public string userID;
        public string Password;
        public string companyID;
        public Lead lead;
    }
    public class LeadController : Controller
    {
        public Lead lead { get; set; }

        // GET: Lead
        public ActionResult UploadLead()
        {
            if (this.Session["UserID"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult CreateLead()
        {
            if (this.Session["UserID"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                ViewBag.Welcome = "Welcome " + Session["UserID"];
                return View();
            }

        }



        [HttpGet]
        public ActionResult displayLead()
        {
            if (this.Session["UserID"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                ViewBag.Welcome = "Welcome " + Session["UserID"];
                return View();
            }

        }

        [HttpPost]
        public ActionResult CreateLead([Bind(Include = "ID,fname,lname,cname,cid,enos,arev,role,email,cnumber,address,cphone,fax,site,cemail,lowner,lstatus,desc,status,CreatedDate,CreatedBy")] Lead lead)
        {

          //  Random rnd = new Random();
           // int oID = rnd.Next(1, 1000000);
            //lead.ID = oID.ToString();

            //DateTime localDate = DateTime.Now;
            //DateTime dateOnly = localDate.Date;
            //// String contain = ")\\/\"";

            //string createdDate = "/Date(" + DateTime.Now.ToString("yyyy-MM-dd") + ")/";
            // string createdDate = "\\/Date(" + dateOnly.ToString() + ")\\/";
           // lead.CreatedDate = createdDate;
            lead.CreatedBy = "Varshad";
            var obj = lead;
            var webAddr = "http://localhost:8733/Design_Time_Addresses/ExcelManageITService/Service1/AddLead";
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(webAddr);
            httpWebRequest.ContentType = "application/json; charset=utf-8";
            httpWebRequest.Method = "POST";




            var newObj = new jsonLead
            {
                userID = "Varshad",
                Password = "password",
                companyID = "Demo",

                lead = obj

            };



            var jsonOppo = new JavaScriptSerializer().Serialize(newObj);

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {

                streamWriter.Write(jsonOppo);
                streamWriter.Flush();
            }
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                Console.WriteLine("Breaking error");
                Console.WriteLine(streamReader.ReadToEnd());
                return RedirectToAction("CreateLead", "Lead");
            }





        }



        public ActionResult LeadGrid([DataSourceRequest]DataSourceRequest request)
        {
            return Json(GetLeads().ToDataSourceResult(request));
        }
        private IEnumerable<Lead> GetLeads()
        {
            try
            {
                string json = new JavaScriptSerializer().Serialize(new
                {
                    userID = this.Session["UserID"],
                    Password = this.Session["Password"],
                    companyID = this.Session["CompanyId"],

                });
                // String Url = "http://internservice.ddns.net/ExcelManageITService.ManageITService.svc/ViewLead";
                String Url = "http://localhost:8733/Design_Time_Addresses/ExcelManageITService/Service1/ViewLead";
                Util.ExcelManageITUtil excelManageITUtil = new Util.ExcelManageITUtil();
                String response = excelManageITUtil.callWebService(Url, json);

                Newtonsoft.Json.Linq.JObject responseJson = JObject.Parse(response);
                Newtonsoft.Json.Linq.JArray LeadArray = JArray.Parse(responseJson["ViewLeadResult"].ToString());
                List<Lead> leads = new List<Lead>();
                foreach (var lead in LeadArray)
                {

                    Lead u = new Lead();
                    u.ID = lead["ID"].ToString();
                    u.fname = lead["fname"].ToString();
                    u.lname = lead["lname"].ToString();
                    u.lowner = lead["lowner"].ToString();
                    u.role = lead["role"].ToString();
                    u.email = lead["email"].ToString();
                    u.desc = lead["description"].ToString();
                    u.cnumber = lead["cnumber"].ToString();
                    u.cphone = lead["cphone"].ToString();

                    u.fax = lead["fax"].ToString();

                    // u.status = lead["status"];
                    u.site = lead["site"].ToString();
                    u.enos = lead["enos"].ToString();
                    u.lstatus = lead["lstatus"].ToString();
                    u.cname = lead["cname"].ToString();

                    u.CreatedDate = lead["CreatedDate"].ToString();

                    // u.CreatedBy = lead["CreatedBy"].ToString();
                    leads.Add(u);
                }
                return leads;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public class ViewLeadList
        {
            public List<Lead> ViewLeadResult { get; set; }
        }


        [HttpGet]
        public ActionResult ModifyLead(String id)
        {
            var singleObj = new Lead();


            String res = null;
            var webAddr = "http://localhost:8733/Design_Time_Addresses/ExcelManageITService/Service1/GetLead";
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(webAddr);
            httpWebRequest.ContentType = "application/json; charset=utf-8";
            httpWebRequest.Method = "POST";

            var jsonViewLead = new JavaScriptSerializer().Serialize(new
            {
                userID = "Varshad",
                Password = "password",
                companyID = "Demo",
                ID = id

            });

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {

                streamWriter.Write(jsonViewLead);
                streamWriter.Flush();
            }
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {

                res = streamReader.ReadToEnd();



                JObject responseJson = JObject.Parse(res);
                string result = responseJson["GetLeadResult"].Value<String>();
                Console.WriteLine(result);


                singleObj = JsonConvert.DeserializeObject<Lead>(result);



            }




            return View(singleObj);
        }

        [HttpGet]
        public ActionResult DeleteLead(String id)
        {
            var singleObj = new Lead();


            String res = null;
            var webAddr = "http://localhost:8733/Design_Time_Addresses/ExcelManageITService/Service1/DeleteLead";
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(webAddr);
            httpWebRequest.ContentType = "application/json; charset=utf-8";
            httpWebRequest.Method = "POST";

            var jsonViewLead = new JavaScriptSerializer().Serialize(new
            {
                userID = "Varshad",
                Password = "password",
                companyID = "Demo",
                ID = id

            });

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {

                streamWriter.Write(jsonViewLead);
                streamWriter.Flush();
            }
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {

                res = streamReader.ReadToEnd();



                JObject responseJson = JObject.Parse(res);
              //  string result = responseJson["GetLeadResult"].Value<String>();
               // Console.WriteLine(result);


              //  singleObj = JsonConvert.DeserializeObject<Lead>(result);



            }




            return RedirectToAction("displayLead", "Lead");
        }

        [HttpPost]
        public ActionResult ModifyLead([Bind(Include = "ID,fname,lname,cname,cid,enos,arev,role,email,cnumber,address,cphone,fax,site,cemail,lowner,lstatus,desc,status,CreatedDate,CreatedBy")] Lead lead)
        {







            //string createdDate = System.DateTime.Now;

            // oppo.CreatedDate = createdDate;
            //oppo.CreatedBy = "Varshad";
            var obj = lead;



            var webAddr = "http://localhost:8733/Design_Time_Addresses/ExcelManageITService/Service1/ModifyLead";
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(webAddr);
            httpWebRequest.ContentType = "application/json; charset=utf-8";
            httpWebRequest.Method = "POST";




            var newObj = new jsonLead
            {
                userID = "Varshad",
                Password = "password",
                companyID = "Demo",

                lead = obj
               

            };



            var jsonOppo = new JavaScriptSerializer().Serialize(newObj);

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {

                streamWriter.Write(jsonOppo);
                streamWriter.Flush();
            }
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                Console.WriteLine("Breaking error");
                Console.WriteLine(streamReader.ReadToEnd());

            }

            return RedirectToAction("displayLead", "Lead");

        }


    }
}
