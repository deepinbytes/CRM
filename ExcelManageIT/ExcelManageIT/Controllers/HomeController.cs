using ExcelManageIT.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace ExcelManageIT.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Login()
        {
            if (this.Session["UserID"] != null)
            {
                return RedirectToAction("CreateOpportunities", "Opportunities");
            }
            ViewBag.Message = "Your Login page.";

            return View();
        }

        [HttpPost]
        public ActionResult Login(Models.User user)
        {
            if (ModelState.IsValid)
            {
               string json = new JavaScriptSerializer().Serialize(new
               {
               userID = user.UserId,
               Password = user.Password,
               companyID = user.Company
               });
               String Url = "http://internservice.ddns.net/ExcelManageITService.ManageITService.svc/Login";
               Util.ExcelManageITUtil excelManageITUtil = new Util.ExcelManageITUtil();
               String response = excelManageITUtil.callWebService(Url, json);
               JObject responseJson = JObject.Parse(response);
               string result = responseJson["LoginResult"].Value<String>();
               Console.WriteLine(result);
               if (result.Equals("Success"))
                {
                   
                    this.Session["UserID"] = user.UserId;
                    this.Session["CompanyId"] = user.Company;
                    this.Session["Password"] = user.Password;
                    this.Session.Timeout = 10;
                   return RedirectToAction("CreateOpportunities", "Opportunities");
                }
                else
                {
                    ViewBag.Error = result;
                    ModelState.AddModelError("", result);
                }
            }
            return View(user);
        }

        public ActionResult Logout()
        {
            
            this.Session.Remove("UserID");
            this.Session.Remove("CompanyId");
            this.Session.Remove("Password");
            this.Session.Clear();
            this.Session.Abandon();
            return RedirectToAction("Login", "Home");
        }
     
    }
}