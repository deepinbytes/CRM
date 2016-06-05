
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;


namespace ExcelManageITService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IManageITService" in both code and config file together.
    [ServiceContract]
    public interface IManageITService
    {
        [OperationContract]
        [WebInvoke(Method= "POST",ResponseFormat=WebMessageFormat.Json,RequestFormat=WebMessageFormat.Json,BodyStyle=WebMessageBodyStyle.Wrapped)]
        string Login(string userID, string Password, string companyID);
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]

        string AddUser(string userID, string Password, string companyID, User user);
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]

        string ViewUser(string userID, string Password, string companyID);
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        string AddRole (string userID, string Password, string companyID, Role role);
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        string AddToAccessControl(string userID, string Password, string companyID, AccessControl accessControl);
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        string GetUser(string userID, string Password, string companyID, string userIDToGet);

        [OperationContract]
        string GetData(int value);



        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        string AddOpportunity(string userID, string Password, string companyID, Opportunity opportunity);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        string ViewOpportunity(string userID, string Password, string companyID); 

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        string GetOpportunity(string userID, string Password, string companyID, string id);


        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        string AddCustomer(string userID, string Password, string companyID, Customer customer);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        string ViewCustomer(string userID, string Password, string companyID);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        string AddContact(string userID, string Password, string companyID, Contact contact);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        string ViewContact(string userID, string Password, string companyID);

        // PRODUCT

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        string AddProduct(string userID, string Password, string companyID, Product product);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        string ViewProduct(string userID, string Password, string companyID);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        string ModifyLead(string userID, string Password, string companyID, Lead lead);
        
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        string DeleteLead(string userID, string Password, string companyID, string ID);

        

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        string AddLead(string userID, string Password, string companyID, Lead lead);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        [OperationContract]
        [WebGet(UriTemplate = "DownloadFile/{fileName}")]
        Stream DownloadFile(string fileName);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/UploadFile?fileName={fileName}")]
        void UploadFile(string fileName, Stream stream);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]

        string ViewLead(string userID, string Password, string companyID);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        string GetLead(string userID, string Password, string companyID, string ID);
        // TODO: Add your service operations here
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "ExcelManageITService.ContractType".

    [DataContract]
    public class LeadProfile
    {
         [DataMember]
        public string ID;
        [DataMember]

        public string fname;
        [DataMember]

        public string lname;
        [DataMember]

        public string cname;

        [DataMember]

        public string cid;

        [DataMember]

        public string enos;

        [DataMember]

        public string arev;

        [DataMember]

        public string role;

        [DataMember]

        public string email;

        [DataMember]

        public string cnumber;
        [DataMember]

        public string address;
        [DataMember]

        public string cphone;
        [DataMember]

        public string fax;
        [DataMember]

        public string site;
        [DataMember]

        public string cemail;
        [DataMember]

        public string lowner;
        [DataMember]

        public string lstatus;
        [DataMember]

        public string desc;
        [DataMember]

        public bool status;
         [DataMember]
        public string CreatedDate { get; set; }
         [DataMember]
        public string CreatedBy { get; set; }
         [DataMember]
        public virtual User User { get; set; }
    }

    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
