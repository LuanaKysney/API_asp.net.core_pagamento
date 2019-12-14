using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Pagamento.Models
{
    public class AddressClient
    {
        [Key]
        public Guid Id { get; set; }
        //Complemento
        public string line1 { get; set; }
        //Complemento
        public string line2 { get; set; }
        public string neighborhood { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string postal_code { get; set; }
        public string country_code { get; set; }
      
    }
}
