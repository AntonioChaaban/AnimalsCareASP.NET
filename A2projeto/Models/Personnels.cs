using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace A2projeto.Models
{
    public class Personnels
    {
        public int id { get; set; }
        public String name { get; set; }
        public string documentNumber { get; set; }
        public String gender { get; set; }
        public String workShift { get; set; }
        public Expertises expertises { get; set; }
        public DateTime memberSince { get; set; }

        public string CPFFormatado
        {
            get
            {
                if (string.IsNullOrEmpty(documentNumber))
                    return string.Empty;

                return Convert.ToUInt64(documentNumber).ToString(@"000\.000\.000\-00");
            }
            set
            {
                // Remove caracteres especiais do CPF
                documentNumber = value?.Replace(".", "").Replace("-", "");
            }
        }
    }
}