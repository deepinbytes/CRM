using ExcelManageITService.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelManageITService.Authentication
{
    class ManageAccessControl
    {
        public string AddToAccessControl(AccessControl accessControl, String companyDatabase)
        {
            try
            {
                using (var context = new ManageITDemoEntities(ConnectionOperation.CreateEntityConnection(companyDatabase)))
                {
                    context.AccessControls.Add(accessControl);
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
