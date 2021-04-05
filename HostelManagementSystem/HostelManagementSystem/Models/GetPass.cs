using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HostelManagementSystem.Models
{
    public class GetPass
    {
        public int id { get; set; }
        public string StudentId { get; set; }
        public string Name { get; set; }
        public string  Place{ get; set; }
        public DateTime Dept_date { get; set; }
        public DateTime Arrival_date { get; set; }
        
    }
}
