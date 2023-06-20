using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace A2projeto.Models
{
    public class Animals
    {
        public int id { get; set; }
        public String name { get; set; }

        public String tag_code { get; set; }

        //Enum
        public Specimens specimen { get; set; }

        public DateTime dateBirth { get; set; }

        public int age { get; set; }

        public String gender { get; set; }

        public String locomotion { get; set; }

        public String color { get; set; }

        public String characteristics { get; set; }

        public string feedings { get; set; }

        public string healthRecords { get; set; }

        public bool extinct { get; set; }

        public String reproduction_characteristcs { get; set; }

        public String standards_of_care { get; set; }

        public string sector { get; set; }
    }
}