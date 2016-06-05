using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExcelManageIT.Models
{
    public partial class Contact
    {
        public string ContactID { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
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
        public string NextStep { get; set; }
        public string MainSource { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }

        public virtual User User { get; set; }
    }
}