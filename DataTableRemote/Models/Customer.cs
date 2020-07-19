using System;

namespace DataTableRemote.Models
{
    public class Customer
    {
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string position { get; set; }
        public string office { get; set; }
        public DateTime start_date { get; set; }
        public decimal salary { get; set; }
    }
}