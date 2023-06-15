using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace A2projeto.Models
{
    public class Feedings
    {
        public int id { get; set; }

        public string name { get; set; }

        public String feedingSchedule { get; set; }

        public int feedingFrequencyPerDay { get; set; }

        //Enum
        public EatingHabits eatingHabits { get; set; }

        public List<PerformFeedings> performFeeding { get; set; }
    }
}