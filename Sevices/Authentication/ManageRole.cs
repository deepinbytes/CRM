using ExcelManageITService.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelManageITService.Authentication
{
    class ManageRole
    {
        public string AddRole(Role role, String companyDatabase)
        {
            try
            {
                using (var context = new ManageITDemoEntities(ConnectionOperation.CreateEntityConnection(companyDatabase)))
                {
                    context.Roles.Add(role);
                    context.SaveChanges();
                    return "success";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
       
    }
}
