using ExcelManageIT.Models;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace ExcelManageIT.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult CreateUser()
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
        public ActionResult CreateUser(Models.User user)
        {
            if (ModelState.IsValid)
            {
                user.CreatedBy = (string)this.Session["UserID"];
                user.CreatedDate = System.DateTime.Now;
                user.Password = System.Web.Security.Membership.GeneratePassword(12, 3);
                user.IsActive = "Y";


                string json = new JavaScriptSerializer().Serialize(new
                {
                    userID = this.Session["UserID"],
                    Password = this.Session["Password"],
                    companyID = this.Session["CompanyId"],
                    user = user
                });
                //String Url = "http://internservice.ddns.net/ExcelManageITService.ManageITService.svc/AddUser";
                String Url = "http://localhost:8733/Design_Time_Addresses/ExcelManageITService/Service1/AddUser";
                Util.ExcelManageITUtil excelManageITUtil = new Util.ExcelManageITUtil();
                String response = excelManageITUtil.callWebService(Url, json);
                JObject responseJson = JObject.Parse(response);
                string result = responseJson["AddUserResult"].Value<String>();
                Console.WriteLine(result);
                if (result.Equals("success"))
                {
                    ViewBag.Message = "User " + user.UserId + " Added";
                    return View();
                }
                else
                {
                    ViewBag.Error = result;
                    ModelState.AddModelError("", result);
                }
            }
            return View(user);
        }
        public ActionResult ViewUser()
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
        public ActionResult UsersList([DataSourceRequest]DataSourceRequest request)
        {
            return Json(GetUsers().ToDataSourceResult(request));
        }
        private IEnumerable<User> GetUsers()
        {
            try {
                string json = new JavaScriptSerializer().Serialize(new
                {
                    userID = this.Session["UserID"],
                    Password = this.Session["Password"],
                    companyID = this.Session["CompanyId"],

                });
                // String Url = "http://internservice.ddns.net/ExcelManageITService.ManageITService.svc/ViewUser";
                String Url = "http://localhost:8733/Design_Time_Addresses/ExcelManageITService/Service1/ViewUser";
                Util.ExcelManageITUtil excelManageITUtil = new Util.ExcelManageITUtil();
                String response = excelManageITUtil.callWebService(Url, json);
                //var users = new JavaScriptSerializer().Deserialize<dynamic>(response);
                //Console.WriteLine(users["ViewUserResult"][0].);
                JObject responseJson = JObject.Parse(response);
                JArray UserArray =JArray.Parse(responseJson["ViewUserResult"].ToString());
                List<User> users = new List<User>();
                foreach(var user in UserArray)
                {
                    
                    User u = new User();
                    u.UserId = user["UserId"].ToString();
                    u.FirstName = user["FirstName"].ToString();
                    u.MiddleName = user["MiddleName"].ToString();
                    u.LastName = user["LastName"].ToString();
                    u.Gender = user["Gender"].ToString();
                    u.RoleID = user["RoleID"].ToString();
                    u.EmployeeId = user["EmployeeId"].ToString();
                    u.AddressLine1 = user["AddressLine1"].ToString();
                    u.AddressLine2 = user["AddressLine2"].ToString();
                    u.City = user["City"].ToString();
                    u.State = user["State"].ToString();
                    u.EmailId = user["EmailId"].ToString();
                    u.ZIP = user["ZIP"].ToString();
                    u.ContactNumber = user["ContactNumber"].ToString();
                    u.Department = user["Department"].ToString();
                    u.Designation = user["Designation"].ToString();
                    u.Company = user["Company"].ToString();
                    u.Theme= user["Theme"].ToString();
                    u.CreatedBy = user["CreatedDate"].ToString();
                    u.LastLogin = (DateTime)(user["LastLogin"]);
                    u.CreatedBy = user["CreatedBy"].ToString();
                    users.Add(u);
                }
                return users;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
    public class ViewUserList
    {
        public List<User> ViewUserResult { get; set; }
    }

}