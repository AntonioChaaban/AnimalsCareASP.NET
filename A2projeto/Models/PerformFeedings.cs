using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace A2projeto.Models
{
    public class PerformFeedings
    {
        public int id { get; set; }
        public string food { get; set; }
        public string feedings { get; set; }
        public int quantity { get; set; }

        // pessoa que alimentou o animal
        public string UserId { get; set; }
        public DateTime feedingDate { get; set; }
    }
}