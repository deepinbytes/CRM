using ExcelManageITService.Authentication;
using ExcelManageITService.Users;
using ExcelManageITService.Opportunities;
using ExcelManageITService.Customers;
using ExcelManageITService.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;
using ExcelManageITService.Leads;
using System.Web.Hosting;
using FileHelpers;
using System.IO;

using System.ServiceModel.Web;

using System.Reflection;
using ExcelManageITService.Contacts;

namespace ExcelManageITService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class ManageITService : IManageITService
    {

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public string Login(string userID, string Password, string companyID)
        {
            Login login = new Login();
            return login.Authenticate(userID, Password, companyID);
        }

        public string AddUser(string userID, string Password, string companyID, User user)
        {
            Login login = new Login();
            if (login.Authenticate(userID, Password, companyID) == "Success")
            {
                string companyDatabase = login.GetCompanyDatabase(companyID);
                ManageUser manageUser = new ManageUser();
                return manageUser.AddUser(user, companyDatabase);

            }
            return "Error";
        }
        public string ViewUser(string userID, string Password, string companyID)
        {
             Login login = new Login();
             if (login.Authenticate(userID, Password, companyID) == "Success")
             {
                 string companyDatabase = login.GetCompanyDatabase(companyID);
                 ManageUser manageUser = new ManageUser();
                 return manageUser.ViewUser(companyDatabase);
             }
             return "Authorization failed";
            
             
            
        }



        public string AddRole(string userID, string Password, string companyID, Role role)
        {
            Login login = new Login();
            if (login.Authenticate(userID, Password, companyID) == "Success")
            {
                string companyDatabase = login.GetCompanyDatabase(companyID);
                ManageRole manageRole = new ManageRole();
                return manageRole.AddRole(role, companyDatabase);

            }
            return "Error";
        }


        public string AddToAccessControl(string userID, string Password, string companyID, AccessControl accessControl)
        {
            Login login = new Login();
            if (login.Authenticate(userID, Password, companyID) == "Success")
            {
                string companyDatabase = login.GetCompanyDatabase(companyID);
                ManageAccessControl manageAcccessControl = new ManageAccessControl();
                return manageAcccessControl.AddToAccessControl(accessControl, companyDatabase);

            }
            return "Error";
        }

        public string AddOpportunity(string userID, string Password, string companyID, Opportunity opportunity)
        {
            Login login = new Login();
            if (login.Authenticate(userID, Password, companyID) == "Success")
            {
                string companyDatabase = login.GetCompanyDatabase(companyID);
                ManageOpportunity manageOpportunity = new ManageOpportunity();
                return manageOpportunity.AddOpportunity(opportunity, companyDatabase);

            }
            return "Error";
        }



        public string ViewOpportunity(string userID, string Password, string companyID)
        {
            Login login = new Login();
            if (login.Authenticate(userID, Password, companyID) == "Success")
            {
                string companyDatabase = login.GetCompanyDatabase(companyID);
                ManageOpportunity manageOpportunity = new ManageOpportunity();
                return manageOpportunity.ViewOpportunity(companyDatabase);

            }
            //Customer cu = new Customer();
            //List<Customer> cusss = new List<Customer>();
            //cusss.Add(cu);
            return "Error";
        }


        public string GetOpportunity(string userID, string Password, string companyID, string id)
        {
            Login login = new Login();
            if (login.Authenticate(userID, Password, companyID) == "Success")
            {
                string companyDatabase = login.GetCompanyDatabase(companyID);
                ManageOpportunity manageOpportunity = new ManageOpportunity();
                return manageOpportunity.GetOpportunity(companyDatabase, id);

            }
           
            return "Error";
        }




        public string AddCustomer(string userID, string Password, string companyID, Customer customer)
        {
            Login login = new Login();
            if (login.Authenticate(userID, Password, companyID) == "Success")
            {
                string companyDatabase = login.GetCompanyDatabase(companyID);
                ManageCustomers manageCustomers = new ManageCustomers();
                return manageCustomers.AddCustomer(customer, companyDatabase);

            }
            return "Error";
        }



        public string ViewCustomer(string userID, string Password, string companyID)
        {
            Login login = new Login();
            if (login.Authenticate(userID, Password, companyID) == "Success")
            {
                string companyDatabase = login.GetCompanyDatabase(companyID);
                ManageCustomers manageCustomers = new ManageCustomers();
                return manageCustomers.ViewCustomer(companyDatabase);

            }
            //Customer cu = new Customer();
            //List<Customer> cusss = new List<Customer>();
            //cusss.Add(cu);
            return "Error";
        }


        public string AddContact(string userID, string Password, string companyID, Contact contact)
        {
            Login login = new Login();
            if (login.Authenticate(userID, Password, companyID) == "Success")
            {
                string companyDatabase = login.GetCompanyDatabase(companyID);
                ManageContacts manageContact = new ManageContacts();
                return manageContact.AddContact(contact, companyDatabase);

            }
            return "Error";
        }


        public string ViewContact(string userID, string Password, string companyID)
        {
            Login login = new Login();
            if (login.Authenticate(userID, Password, companyID) == "Success")
            {
                string companyDatabase = login.GetCompanyDatabase(companyID);
                ManageContacts manageContacts = new ManageContacts();
                return manageContacts.ViewContact(companyDatabase);

            }
            //Customer cu = new Customer();
            //List<Customer> cusss = new List<Customer>();
            //cusss.Add(cu);
            return "Error";
        }



        public string AddLead(string userID, string Password, string companyID, Lead leadprofile)
        {

            Login login = new Login();
            if (login.Authenticate(userID, Password, companyID) == "Success")
            {
                string companyDatabase = login.GetCompanyDatabase(companyID);
                ManageLead Leads = new ManageLead();

                return Leads.CreateLead(leadprofile, companyDatabase);

            }
            return "Error";
        }

        public string ModifyLead(string userID, string Password, string companyID, Lead leadprofile)
        {

            Login login = new Login();
            if (login.Authenticate(userID, Password, companyID) == "Success")
            {
                string companyDatabase = login.GetCompanyDatabase(companyID);
                ManageLead Leads = new ManageLead();

                return Leads.ModifyLead(leadprofile, companyDatabase);

            }
            return "Error";
        }

        public string DeleteLead(string userID, string Password, string companyID, string ID)
        {

            Login login = new Login();
            if (login.Authenticate(userID, Password, companyID) == "Success")
            {
                string companyDatabase = login.GetCompanyDatabase(companyID);
                ManageLead Leads = new ManageLead();

                return Leads.DeleteLead(companyDatabase,ID);

            }
            return "Error";
        }


        public string AddProduct(string userID, string Password, string companyID, Product product)
        {
            Login login = new Login();
            if (login.Authenticate(userID, Password, companyID) == "Success")
            {
                string companyDatabase = login.GetCompanyDatabase(companyID);
                ManageProduct manageProduct = new ManageProduct();
                return manageProduct.AddProduct(product, companyDatabase);
            }
            return "Error";
        }


        public string ViewProduct(string userID, string Password, string companyID)
        {
            Login login = new Login();
            if (login.Authenticate(userID, Password, companyID) == "Success")
            {
                string companyDatabase = login.GetCompanyDatabase(companyID);
                ManageProduct manageProduct = new ManageProduct();
                return manageProduct.ViewProduct(companyDatabase);
            }
            return "Authorization failed";
        }


        public Stream DownloadFile(string fileName)
        {
            string downloadFilePath = Path.Combine(HostingEnvironment.MapPath("~/Files/Downloads"), fileName);
            String headerInfo = "attachment; filename=" + fileName;
            WebOperationContext.Current.OutgoingResponse.Headers["Content-Disposition"] = headerInfo;
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/octet-stream";
            return File.OpenRead(downloadFilePath);
        }
        public string ViewLead(string userID, string Password, string companyID)
        {
            List<User> returnList = new List<User>();
            Login login = new Login();
            if (login.Authenticate(userID, Password, companyID) == "Success")
            {
                string companyDatabase = login.GetCompanyDatabase(companyID);
                ManageLead managelead = new ManageLead();
                return managelead.ViewLead(companyDatabase);
            }
            return "Authorization failed";



        }

        public string GetLead(string userID, string Password, string companyID, string ID)
        {
            Login login = new Login();
            if (login.Authenticate(userID, Password, companyID) == "Success")
            {
                string companyDatabase = login.GetCompanyDatabase(companyID);
                ManageLead managelead = new ManageLead();
                return managelead.GetLead(companyDatabase, ID);

            }

            return "Error";
        }

        public void UploadFile(string fileName, Stream stream)
        {
            var path = HostingEnvironment.MapPath("~");
            if (path == null)
            {
                var uriPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
                path = new Uri(uriPath).LocalPath;
            }
            string FilePath = Path.Combine(path, fileName);
            try
            {


                int length = 0;
                using (FileStream writer = new FileStream(FilePath, FileMode.Create))
                {
                    int readCount;
                    var buffer = new byte[8192];
                    while ((readCount = stream.Read(buffer, 0, buffer.Length)) != 0)
                    {
                        writer.Write(buffer, 0, readCount);
                        length += readCount;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                var engine = new FileHelperEngine<RecordMapping>();

                var result = engine.ReadFile(FilePath);
                foreach (RecordMapping rmap in result)
                {
                    ManageITDemoEntities ab = new ManageITDemoEntities();
                    Lead sf = new Lead();
                    sf.ID = Guid.NewGuid().ToString().GetHashCode().ToString("x").Substring(1, 5);
                    sf.address = rmap.address;
                    sf.arev = rmap.arev;
                    sf.cemail = rmap.cemail;
                    sf.cid = rmap.cid;
                    sf.cname = rmap.cname;
                    sf.cnumber = rmap.cnumber;
                    sf.cphone = rmap.cphone;
                    sf.description = rmap.desc;
                    sf.email = rmap.email;
                    sf.enos = rmap.enos;
                    sf.fax = rmap.fax;
                    sf.fname = rmap.fname;
                    sf.lname = rmap.lname;
                    sf.lowner = rmap.lowner;
                    sf.lstatus = rmap.lstatus;
                    sf.role = rmap.role;
                    sf.site = rmap.site;
                    ab.Leads.Add(sf);
                    ab.SaveChanges();
                }
            }
        }




        public string GetUser(string userID, string Password, string companyID, string userIDToGet)
        {
            Login login = new Login();
            if (login.Authenticate(userID, Password, companyID) == "Success")
            {
                string companyDatabase = login.GetCompanyDatabase(companyID);
                ManageUser manageUser = new ManageUser();
                return manageUser.GetUser(userIDToGet,companyDatabase);
            }
            return "Authorization failed";
        }
    }

}