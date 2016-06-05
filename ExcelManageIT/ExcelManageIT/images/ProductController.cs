using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace ExcelManageIT.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult CreateProduct()
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
        public ActionResult CreateProduct(Models.Product product)
        {
            if (ModelState.IsValid)
            {
                product.CreatedBy = (string)this.Session["UserID"];
                product.CreatedDate = System.DateTime.Now;
                product.IsActive = "Y";

                string json = new JavaScriptSerializer().Serialize(new
                {
                    userID = this.Session["UserID"],
                    Password = this.Session["Password"],
                    companyID = this.Session["CompanyId"],
                    product = product
                });
                //String Url = "http://internservice.ddns.net/ExcelManageITService.ManageITService.svc/AddUser";
                String Url = "http://localhost:8733/Design_Time_Addresses/ExcelManageITService/Service1/AddProduct";
                Util.ExcelManageITUtil excelManageITUtil = new Util.ExcelManageITUtil();
                String response = excelManageITUtil.callWebService(Url, json);
                JObject responseJson = JObject.Parse(response);
                string result = responseJson["AddProductResult"].Value<String>();
                Console.WriteLine(result);
                if (result.Equals("success"))
                {
                    ViewBag.Message = "Product " + product.ProductName + " Added with ProductId = " + product.ProductId;
                    return View();
                }
                else
                {
                    ViewBag.Error = result;
                    ModelState.AddModelError("", result);
                }
            }
            return View(product);
        }
    }
}