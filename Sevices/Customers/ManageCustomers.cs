using ExcelManageITService.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Script.Serialization;

using Newtonsoft.Json;

namespace ExcelManageITService.Customers
{


    public class CustomerJson
    {
        [JsonProperty("customer")]
        public IEnumerable<Customer>  customer { get; set; }
    }


    class ManageCustomers
    {


        public string AddCustomer(Customer customer, String companyDatabase)
        {
            try
            {
                using (var context = new ManageITDemoEntities(ConnectionOperation.CreateEntityConnection(companyDatabase)))
                {
                    context.Customers.Add(customer);
                    context.SaveChanges();
                    return "success";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        public string ViewCustomer(String companyDatabase)
        {
            try
            {
                using (var context = new ManageITDemoEntities(ConnectionOperation.CreateEntityConnection(companyDatabase)))
                {
                  
                    context.Configuration.ProxyCreationEnabled = false;
                    var Cust = context.Customers.ToArray<Customer>();
                    //CustomerJson newCust = new CustomerJson();
                   // newCust.Customer.
                    
                   var jsonSerialiser = new JavaScriptSerializer();
                    var json = jsonSerialiser.Serialize(Cust);
                    return json;
                }
            }
            catch (Exception ex)
            {
                //Customer cu = new Customer();
                //List<Customer> cusss = new List<Customer>();
                //cusss.Add(cu);
                return ex.Message;

            }
        }


    }
}
