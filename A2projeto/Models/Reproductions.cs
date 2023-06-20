using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace A2projeto.Models
{
    public class Reproductions
    {
        public int id { get; set; }
        public string animalMale { get; set; }
        public string animalFemale { get; set; }
        public DateTime expectedMatingDate { get; set; }
        public DateTime matingDateHeld { get; set; }

        public String scenarioDescription { get; set; }
        public String descriptionAct { get; set; }

        public bool pregnancy { get; set; }

    }
}