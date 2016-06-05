using ExcelManageITService.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace ExcelManageITService.Opportunities
{


    public class OpportunityJson
    {
        [JsonProperty("customer")]
        public IEnumerable<Opportunity> opportunity { get; set; }
    }


    class ManageOpportunity
    {

        public string AddOpportunity(Opportunity opportunity, String companyDatabase)
        {
            try
            {
                using (var context = new ManageITDemoEntities(ConnectionOperation.CreateEntityConnection(companyDatabase)))
                {
                    context.Opportunities.Add(opportunity);
                    context.SaveChanges();
                    return "success";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }



        public string ViewOpportunity(String companyDatabase)
        {
            try
            {
                using (var context = new ManageITDemoEntities(ConnectionOperation.CreateEntityConnection(companyDatabase)))
                {

                    context.Configuration.ProxyCreationEnabled = false;
                    var Cust = context.Opportunities.ToArray<Opportunity>();


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

        public string GetOpportunity(String companyDatabase, String id)
        {
            try
            {
                using (var context = new ManageITDemoEntities(ConnectionOperation.CreateEntityConnection(companyDatabase)))
                {
                    var query = context.Opportunities.Where(o => o.OpportunityID == id);
                    var OpportunityData = query.FirstOrDefault<Opportunity>();
                    context.Configuration.ProxyCreationEnabled = false;
                    //var Cust = context.Opportunities.ToArray<Opportunity>();


                    List<string> propertiesToSerialize = new List<string>(new string[]
{
"OpportunityID","Title","FirstName","MiddleName","LastName","CompanyName","Designation","AddressLine1" ,"AddressLine2","City","State","ZIP","ContactNumber","EmailID","Owner","Source","Status","Description","IsActive","Revenue","CampaignSource","Probability","NextStep","MainSource","CreatedDate","CreatedBy"

});

                    DynamicContractResolver contractResolver = new DynamicContractResolver(propertiesToSerialize);
                    string json = JsonConvert.SerializeObject(OpportunityData, Formatting.None,
    new JsonSerializerSettings()
    {
        ContractResolver = contractResolver,
        ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
    });




                    //var jsonSerialiser = new JavaScriptSerializer();
                    //var json = JsonConvert.SerializeObject(OpportunityData);
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
