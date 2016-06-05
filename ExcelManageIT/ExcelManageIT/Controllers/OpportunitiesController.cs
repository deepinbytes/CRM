using ExcelManageIT.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace ExcelManageIT.Controllers
{

    public class jsonOpportunity
    {
        public string userID;
        public string Password;
        public string companyID;
        public Opportunity opportunity;
    }

    public class OpportunitiesController : Controller
    {

        public Opportunity opportunity { get; set; }


        // GET: Opportunities
        [HttpGet]
        public ActionResult CreateOpportunities()
        {
            if (this.Session["UserID"] == null)
            {
                return View();
                //return RedirectToAction("Login","Home");
            }
            else
            {
                ViewBag.Welcome = "Welcome " + Session["UserID"];
                return View();
            }
            
        }


        [HttpPost]
        public ActionResult CreateOpportunities([Bind(Include = "OpportunityID,Title,FirstName,MiddleName,LastName,CompanyName,Designation,AddressLine1,AddressLine2,City,State,ZIP,ContactNumber,EmailId,Owner,Source,Status,Description,IsActive,Revenue,CampaignSource,Probability,NextStep,MainSource,CreatedDate,CreatedBy")] Opportunity oppo)
        {

            Random rnd = new Random();
            int oID = rnd.Next(1, 1000000);
            oppo.OpportunityID =  oID.ToString();
            
            //DateTime localDate = DateTime.Now;
            //DateTime dateOnly = localDate.Date;
            //// String contain = ")\\/\"";
            
            string createdDate = "/Date(" + DateTime.Now.ToString("yyyy-MM-dd") + ")/";
           // string createdDate = "\\/Date(" + dateOnly.ToString() + ")\\/";
                oppo.CreatedDate = createdDate;
            oppo.CreatedBy = "Varshad";
            var obj = oppo;
            var webAddr = "http://localhost:8733/Design_Time_Addresses/ExcelManageITService/Service1/AddOpportunity";
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(webAddr);
            httpWebRequest.ContentType = "application/json; charset=utf-8";
            httpWebRequest.Method = "POST";

         
           

        var newObj = new jsonOpportunity
        {
                userID = "Varshad",
                Password = "password",
                companyID = "Demo",

                opportunity = obj
              
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
                return RedirectToAction("CreateOpportunities", "Opportunities");
            }



        

        }





        [HttpGet]
        public ActionResult ViewOpportunities()
        {


            var newDSObj = new List<Opportunity>();



            String res = null;
            var webAddr = "http://localhost:8733/Design_Time_Addresses/ExcelManageITService/Service1/ViewOpportunity";
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
                string result = responseJson["ViewOpportunityResult"].Value<String>();
                Console.WriteLine(result);


                newDSObj = JsonConvert.DeserializeObject<List<Opportunity>>(result);



            }


            ViewBag.MyList = newDSObj;

            return View();



        }


        [HttpGet]
        public ActionResult ModifyOpportunities(int id)
        {
            var singleOppObj = new Opportunity();


            String res = null;
            var webAddr = "http://localhost:8733/Design_Time_Addresses/ExcelManageITService/Service1/GetOpportunity";
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(webAddr);
            httpWebRequest.ContentType = "application/json; charset=utf-8";
            httpWebRequest.Method = "POST";

            var jsonViewCust = new JavaScriptSerializer().Serialize(new
            {
                userID = "Varshad",
                Password = "password",
                companyID = "Demo",
                id = id

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
                string result = responseJson["ViewOpportunityResult"].Value<String>();
                Console.WriteLine(result);


                singleOppObj = JsonConvert.DeserializeObject<Opportunity>(result);



            }




            return View(singleOppObj);
        }

        [HttpPost]
        public ActionResult ModifyOpportunities([Bind(Include = "OpportunityID,Title,FirstName,MiddleName,LastName,CompanyName,Designation,AddressLine1,AddressLine2,City,State,ZIP,ContactNumber,EmailId,Owner,Source,Status,Description,IsActive,Revenue,CampaignSource,Probability,NextStep,MainSource,CreatedDate,CreatedBy")] Opportunity oppo)
        {




            


            //string createdDate = System.DateTime.Now;

           // oppo.CreatedDate = createdDate;
            //oppo.CreatedBy = "Varshad";
            var obj = oppo;



            var webAddr = "http://localhost:8733/Design_Time_Addresses/ExcelManageITService/Service1/ModifyOpportunity";
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(webAddr);
            httpWebRequest.ContentType = "application/json; charset=utf-8";
            httpWebRequest.Method = "POST";




            var newObj = new jsonOpportunity
            {
                userID = "Varshad",
                Password = "password",
                companyID = "Demo",

                opportunity = obj

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

            return RedirectToAction("ViewOpportunities", "Opportunities");

        }



        }
    }