using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace A2projeto.Models
{
    public class Infirms
    {
        public int id { get; set; }
        public string healthRecords { get; set; }
        public String name { get; set; }
        public String physicalTreatment { get; set; }
        public String pharmaceuticalTreatment { get; set; }
        public String vaccine { get; set; }
        public String frequencyOfTreatment { get; set; }
        public String durationOfTreatment { get; set; }
        public DateTime treatmentStartDate { get; set; }
        public string UserId { get; set; }
    }
}