using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HostelManagementSystem.Models
{
    public class Menu
    {
        public int id { get; set; }

        public DateTime Date { get; set; }
        public string BreakFastItem1 { get; set; }
        public string BreakFastItem2 { get; set; }
        public string BreakFastItem3 { get; set; }
        public string LunchItem1 { get; set; }
        public string LunchItem2{ get; set; }
        public string LunchItem3{ get; set; }
        public string LunchItem4 { get; set; }
        public string LunchItem5{ get; set; }
        public string LunchItem6{ get; set; }

        public string DinnerItem1 { get; set; }

        public string DinnerItem2 { get; set; }
        public string DinnerItem3 { get; set; }
        public string DinnerItem4 { get; set; }

        public string DinnerItem5 { get; set; }



    }
}
