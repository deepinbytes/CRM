//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ExcelManageITService
{
    using System;
    using System.Collections.Generic;
    
    public partial class Lead
    {
        public string ID { get; set; }
        public string fname { get; set; }
        public string lname { get; set; }
        public string arev { get; set; }
        public string role { get; set; }
        public string email { get; set; }
        public string cnumber { get; set; }
        public string address { get; set; }
        public string cphone { get; set; }
        public string fax { get; set; }
        public string site { get; set; }
        public string cemail { get; set; }
        public string lowner { get; set; }
        public string lstatus { get; set; }
        public string description { get; set; }
        public string cid { get; set; }
        public string enos { get; set; }
        public string status { get; set; }
        public string cname { get; set; }
        public string Createdby { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
    
        public virtual Lead Leads1 { get; set; }
        public virtual Lead Lead1 { get; set; }
    }
}