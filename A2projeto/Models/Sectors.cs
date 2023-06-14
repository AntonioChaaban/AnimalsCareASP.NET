using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace A2projeto.Models
{
    public class Sectors
    {
        public int id { get; set; }
        public String name { get; set; }

        public String playGround { get; set; }

        public bool availableForVisit { get; set; }
    }
}