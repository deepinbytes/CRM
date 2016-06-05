using ExcelManageITService.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using Newtonsoft.Json;

namespace ExcelManageITService.Products
{
    class ManageProduct
    {
        public string AddProduct(Product product, String companyDatabase)
        {
            try
            {
                using (var context = new ManageITDemoEntities(ConnectionOperation.CreateEntityConnection(companyDatabase)))
                {
                    var query = context.Products.Where(p => p.ProductId == product.ProductId);
                    var ProductData = query.FirstOrDefault<Product>();
                    if (ProductData != null)
                    {
                        return "Product already exists with the entered ProductID";
                    }
                    else
                    {
                        context.Products.Add(product);
                        context.SaveChanges();
                        return "success";
                    }
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }  //CreateProduct


        public string ViewProduct(String CompanyDB)
        {
            try
            {
                List<Product> productsList = new List<Product>();
                using (var context = new ManageITDemoEntities(ConnectionOperation.CreateEntityConnection(CompanyDB)))
                {
                    var query = context.Products;
                    foreach (var product in query)
                    {
                        productsList.Add(product);
                    }
                    List<string> propertiesToSerialize = new List<string>(new string[]
{
"ProductId","ProductName","Price","Description","Threshold","CreatedDate","CreatedBy","IsActive" 

});

                    DynamicContractResolver contractResolver = new DynamicContractResolver(propertiesToSerialize);
                    string json = JsonConvert.SerializeObject(productsList, Formatting.None,
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
        } // ViewProduct


    }
}
