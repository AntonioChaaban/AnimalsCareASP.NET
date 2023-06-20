using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace A2projeto.Models
{
    public class HealthRecords
    {
        public int id { get; set; }
        public string name { get; set; }
        public String physicalHealth { get; set; }
        public string animal { get; set; }

        public List<Infirms> infirms { get; set; }

        public DateTime pregnancyIdentificationDay { get; set; }

        public String pregnancyStage { get; set; }

        public DateTime pregnancyDay { get; set; }

        public DateTime dateOfDelivery { get; set; }

        public int numberOfOffspring { get; set; }

        public String description { get; set; }
    }
}