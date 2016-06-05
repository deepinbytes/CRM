using ExcelManageITService.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace ExcelManageITService.Leads
{
    class ManageLead
    {

        public string CreateLead(Lead leadprofile, String companyDatabase)
        {
            if (leadprofile == null)
            {
                return null;
            }
            else
            {
                string result = AddThroughEFORM(leadprofile, companyDatabase);
                leadprofile.status = "true";
                return result;
            }

        }

        public string DeleteLead(String companyDatabase, String ID)
        {
            if (ID == null)
            {
                return null;
            }
            else
            {
                string result = DeleteThroughEFORM(companyDatabase, ID);
               
                return result;
            }

        }

        public string ModifyLead(Lead leadprofile, String companyDatabase)
        {
            if (leadprofile == null)
            {
                return null;
            }
            else
            {
                string result = UpdateThroughEFORM(leadprofile, companyDatabase);
                leadprofile.status = "true";
                return result;
            }

        }
        public string GetLead(String companyDatabase, String ID)
        {
            try
            {
                using (var context = new ManageITDemoEntities(ConnectionOperation.CreateEntityConnection(companyDatabase)))
                {
                    var query = context.Leads.Where(o => o.ID == ID);
                    var LeadData = query.FirstOrDefault<Lead>();
                    context.Configuration.ProxyCreationEnabled = false;
                    

                    List<string> propertiesToSerialize = new List<string>(new string[]
{
"ID","fname","lname","cname","cid","enos","arev","role" ,"email","cnumber","address","cphone","fax","site","cemail","lowner","lstatus","description","status","CreatedDate","CreatedBy"

});

                    DynamicContractResolver contractResolver = new DynamicContractResolver(propertiesToSerialize);
                    string json = JsonConvert.SerializeObject(LeadData, Formatting.None,
    new JsonSerializerSettings()
    {
        ContractResolver = contractResolver,
        ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
    });

                    return json;
                }
            }
            catch (Exception ex)
            {

                return ex.Message;

            }
        }



        public string ViewLead(String CompanyDB)
        {
            try
            {
                List<Lead> allLeads = new List<Lead>();
                using (var context = new ManageITDemoEntities(ConnectionOperation.CreateEntityConnection(CompanyDB)))
                {
                    var query = context.Leads;
                    foreach (var lead in query)
                    {
                        allLeads.Add(lead);
                    }
                    List<string> propertiesToSerialize = new List<string>(new string[]
{
"ID","fname","lname","cname","cid","enos","arev","role" ,"email","cnumber","address","cphone","fax","site","cemail","lowner","lstatus","description","status","CreatedDate","CreatedBy"

});

                    DynamicContractResolver contractResolver = new DynamicContractResolver(propertiesToSerialize);
                    string json = JsonConvert.SerializeObject(allLeads, Formatting.None,
    new JsonSerializerSettings()
    {
        ContractResolver = contractResolver,
        ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
    });
                    return json;
                }


            }
            catch (Exception ex)
            {

                return ex.Message;

            }

        }

        public string AddThroughEFORM(Lead leadprofile,String companyDatabase)
        {


            try
            {
                using (var context = new ManageITDemoEntities(ConnectionOperation.CreateEntityConnection(companyDatabase)))
                {
                    Lead sf = new Lead();
                    sf.ID = Guid.NewGuid().ToString().GetHashCode().ToString("x").Substring(1, 5);
                    sf.address = leadprofile.address;
                    sf.arev = leadprofile.arev;
                    sf.cemail = leadprofile.cemail;
                    sf.cid = leadprofile.cid;
                    sf.cname = leadprofile.cname;
                    sf.cnumber = leadprofile.cnumber;
                    sf.cphone = leadprofile.cphone;
                    sf.description = leadprofile.description;
                    sf.email = leadprofile.email;
                    sf.enos = leadprofile.enos;
                    sf.fax = leadprofile.fax;
                    sf.fname = leadprofile.fname;
                    sf.lname = leadprofile.lname;
                    sf.lowner = leadprofile.lowner;
                    sf.lstatus = leadprofile.lstatus;
                    sf.role = leadprofile.role;
                    sf.site = leadprofile.site;
                    context.Leads.Add(sf);
                    context.SaveChanges();
                    return "SUCCESS";
                }
            }

            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string UpdateThroughEFORM(Lead leadprofile, String companyDatabase)
        {


            try
            {
                using (var context = new ManageITDemoEntities(ConnectionOperation.CreateEntityConnection(companyDatabase)))
                {

                    var original = context.Leads.Find(leadprofile.ID);

                    if (original != null)
                    {
                        //  Lead sf = new Lead();
                        //sf.ID = Id;
                        original.address = leadprofile.address;
                        original.arev = leadprofile.arev;
                        original.cemail = leadprofile.cemail;
                        original.cid = leadprofile.cid;
                        original.cname = leadprofile.cname;
                        original.cnumber = leadprofile.cnumber;
                        original.cphone = leadprofile.cphone;
                        original.description = leadprofile.description;
                        original.email = leadprofile.email;
                        original.enos = leadprofile.enos;
                        original.fax = leadprofile.fax;
                        original.fname = leadprofile.fname;
                        original.lname = leadprofile.lname;
                        original.lowner = leadprofile.lowner;
                        original.lstatus = leadprofile.lstatus;
                        original.role = leadprofile.role;
                        original.site = leadprofile.site;
                       // context.Leads.Add(sf);
                        context.SaveChanges();
                        return "SUCCESS";
                    }
                    else
                        return "FAILURE";
                }
            }

            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string DeleteThroughEFORM(String companyDatabase,String ID)
        {


            try
            {
                using (var context = new ManageITDemoEntities(ConnectionOperation.CreateEntityConnection(companyDatabase)))
                {

                    var lead = new Lead { ID = ID };
                    context.Leads.Attach(lead);
                    context.Leads.Remove(lead);
                    context.SaveChanges();
                    return "SUCCESS";
                }
            }

            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    
}
}