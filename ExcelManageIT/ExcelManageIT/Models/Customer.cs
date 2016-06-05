//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ExcelManageIT.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Customer
    {
        public string CustomerID { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        public string Designation { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZIP { get; set; }
        public string ContactNumber { get; set; }
        public string EmailId { get; set; }
        public string Owner { get; set; }
        public string Source { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public string IsActive { get; set; }
        public string Revenue { get; set; }
        public string CampaignSource { get; set; }
        public int NumberOfOrders { get; set; }
        public string NextStep { get; set; }
        public string MainSource { get; set; }
        public string CreatedDate { get; set; }
        public string CreatedBy { get; set; }
    
    }

    public class Result
    {
        public List<Customer> GetAllCustomersResult { get; set; }
    }

}