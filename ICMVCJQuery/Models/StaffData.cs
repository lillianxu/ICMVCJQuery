using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ICMVCJQuery.Models
{
    public class StaffData
    {
        public int staffId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public int personTypeID { get; set; }

    }
}