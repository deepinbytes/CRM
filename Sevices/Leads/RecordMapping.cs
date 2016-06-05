using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileHelpers;
namespace ExcelManageITService.Leads
{
      [DelimitedRecord("|")]
    class RecordMapping
    {
        public string fname;

        public string lname;


        public string cname;



        public string cid;



        public string enos;



        public string arev;



        public string role;


        public string email;



        public string cnumber;


        public string address;


        public string cphone;


        public string fax;


        public string site;


        public string cemail;


        public string lowner;

        public string lstatus;

        public string desc;


        public bool status;
    }
}
