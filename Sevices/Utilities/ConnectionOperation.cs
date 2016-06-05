using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelManageITService.Utilities
{
    class ConnectionOperation
    {
        internal static String CreateEntityConnection(string databaseName)
        {

            // Start out by creating the SQL Server connection string
            SqlConnectionStringBuilder sqlBuilder = new SqlConnectionStringBuilder();

            // Set the properties for the data source. The IP address network address
            sqlBuilder.DataSource = "137.132.247.145";
            // The name of the database on the server
            sqlBuilder.UserID = "sa";
            sqlBuilder.Password = "Excelforte@1ss";
            sqlBuilder.InitialCatalog = databaseName;
           //   sqlBuilder.IntegratedSecurity = true;
            sqlBuilder.MultipleActiveResultSets = true;
            // Now create the Entity Framework connection string
            EntityConnectionStringBuilder entityBuilder = new EntityConnectionStringBuilder();
            //Set the provider name.
            entityBuilder.Provider = "System.Data.SqlClient";
            // Set the provider-specific connection string.
            entityBuilder.ProviderConnectionString = sqlBuilder.ToString();
           // Set the Metadata location. 
            entityBuilder.Metadata = "res://*/ManageITModel.csdl|res://*/ManageITModel.ssdl|res://*/ManageITModel.msl";

            // Create and entity connection
            EntityConnection conn = new EntityConnection(entityBuilder.ToString());
            return conn.ConnectionString;
        }
    }
}
