using ExcelManageITService.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace ExcelManageITService.Contacts
{


    public class ContactJson
    {
        [JsonProperty("contact")]
        public IEnumerable<Contact> contact { get; set; }
    }


    class ManageContacts
    {


        public string AddContact(Contact contact, String companyDatabase)
        {
            try
            {
                using (var context = new ManageITDemoEntities(ConnectionOperation.CreateEntityConnection(companyDatabase)))
                {
                    context.Contacts.Add(contact);
                    context.SaveChanges();
                    return "success";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }





        public string ViewContact(String companyDatabase)
        {
            try
            {
                using (var context = new ManageITDemoEntities(ConnectionOperation.CreateEntityConnection(companyDatabase)))
                {

                    context.Configuration.ProxyCreationEnabled = false;
                    var Cust = context.Contacts.ToArray<Contact>();
                 

                    var jsonSerialiser = new JavaScriptSerializer();
                    var json = jsonSerialiser.Serialize(Cust);
                    return json;
                }
            }
            catch (Exception ex)
            {
            
                return ex.Message;

            }
        }




    }
}
