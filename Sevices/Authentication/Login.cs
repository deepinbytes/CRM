using ExcelManageITService.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelManageITService.Authentication
{
    class Login
    {
        public string Authenticate(string userID, string Password, string companyID)
        {
            using (var context = new ExcelManageITMasterEntities())
            {
                var query = context.ORGANIZATIONs.Where(o => o.COMPANYID == companyID);
                var CompanyData = query.FirstOrDefault<ORGANIZATION>();
                String database = null;
                if (CompanyData != null)
                {
                    database = CompanyData.DATABASE;

                }else
                {
                    return "Company ID does not exists";
                }
                using (var ctx = new ManageITDemoEntities(
                        ConnectionOperation.CreateEntityConnection(database)))
                {
                    var userQuery = ctx.Users.Where(u => u.UserId == userID && u.Password == Password);
                    var UserData = userQuery.FirstOrDefault<User>();
                    if (UserData == null)
                    {
                        return " Invalid Username Password Combination";
                    }
                    return "Success";

                }
            }
          //  return "error";
        }
        public string GetCompanyDatabase(string companyID)
        {
            using (var context = new ExcelManageITMasterEntities())
            {
                var query = context.ORGANIZATIONs.Where(o => o.COMPANYID == companyID);
                var CompanyData = query.FirstOrDefault<ORGANIZATION>();
                var database = CompanyData.DATABASE;
                if (database == null)
                {
                    return "Company ID does not exists";
                }
                return database;
            }
            
        }
    }
}
