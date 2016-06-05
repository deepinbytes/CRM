using ExcelManageITService.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using Newtonsoft.Json;

namespace ExcelManageITService.Users
{
    class ManageUser
    {
        public string AddUser(User user, String companyDatabase)
        {
            try
            {
                using (var context = new ManageITDemoEntities(ConnectionOperation.CreateEntityConnection(companyDatabase)))
                {
                    var query = context.Users.Where(o => o.UserId == user.UserId);
                    var UserData = query.FirstOrDefault<User>();
                    if (UserData != null)
                    {
                        return "User already exists with the entered UserID";
                    }
                    else
                    {
                        context.Users.Add(user);
                        context.SaveChanges();
                        sendPasswordMail(user);
                        return "success";
                    }
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string GetUser(String userID, String CompanyDB)
        {
            try
            {
                User user = new User();

                using (var context = new ManageITDemoEntities(ConnectionOperation.CreateEntityConnection(CompanyDB)))
                {
                    var query = context.Users.Where(o => o.UserId == userID);
                    var UserData = query.FirstOrDefault<User>();
                    if (UserData == null)
                    {
                        return "User does not exist";
                    }
                    user = UserData;
                    List<string> propertiesToSerialize = new List<string>(new string[]
                                {
                                "UserId","FirstName","MiddleName","LastName","Gender","RoleID","EmployeeId","AddressLine1" ,"AddressLine2","City","State","ZIP","ContactNumber","EmailID","Department","Designation","Company","Theme","CreatedDate","LastLogin","CreatedBy"
                                });

                    DynamicContractResolver contractResolver = new DynamicContractResolver(propertiesToSerialize);
                    string json = JsonConvert.SerializeObject(user, Formatting.None, new JsonSerializerSettings()
                                {
                                    ContractResolver = contractResolver,
                                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                                });
                    return json;
                }


            }
            catch (Exception ex)
            {

                return ex.Message;

            }

        }
        public string ViewUser(String CompanyDB)
        {
            try
            {
                List<User> allUsers = new List<User>();
                using (var context = new ManageITDemoEntities(ConnectionOperation.CreateEntityConnection(CompanyDB)))
                {
                    var query = context.Users;
                    foreach (var user in query)
                    {
                        allUsers.Add(user);
                    }
                    List<string> propertiesToSerialize = new List<string>(new string[]
{
"UserId","FirstName","MiddleName","LastName","Gender","RoleID","EmployeeId","AddressLine1" ,"AddressLine2","City","State","ZIP","ContactNumber","EmailId","Department","Designation","Company","Theme","CreatedDate","LastLogin","CreatedBy"

});

                    DynamicContractResolver contractResolver = new DynamicContractResolver(propertiesToSerialize);
                    string json = JsonConvert.SerializeObject(allUsers, Formatting.None,
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
        public void sendPasswordMail(User user)
        {
            var Body = new System.Text.StringBuilder();
            Body.AppendLine("Dear " + user.FirstName + ",<br/>");
            Body.AppendLine("Greetings from ExcelManageIT team. An account has been created for you at www.ExcelManageIT.com by you or by someone for you. <br/>ExcelManageIT is a light weight Customer Relationship Management System developed by The ExcelForte Software Pte Ltd, Singapore.<br/>");
            Body.AppendLine("Your User Name is : <strong>" + user.UserId + "</strong><br/><br/>");
            Body.AppendLine("Your System Generated Password is : <strong>" + user.Password + "</strong><br/><br/><br/>");
            Body.AppendLine("Warm Regards, <br/>");
            Body.AppendLine("ExcelManageIT Team");
            String Subject = "New Account Registration at www.ExcelManageIT.com";
            String tomail = user.EmailId;
            SendEmail sendemail = new SendEmail();
            sendemail.Sendemail(tomail, Subject, Body.ToString());
        }
    }
}
