using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Pagamento.Models
{
    //Classe representa o usuário que vai ser debitado
    public class CustomerClient
    {
        [Key]
        public Guid customerId { get; set; }
       
            [Required]
            public string first_name { get; set; }

            //CPF ou CNPJ do comprador
            [Required]
            [MaxLength (20)]
            public string taxpayer_id { get; set; }
            [Required]
            public string email { get; set; }
            [Required]
            public Address address { get; set; }
    
        public class Address
        {
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


        public class transacao
        {
            string uri = "https://api.zoop.ws/v1/marketplaces/:marketplace_id/buyers";
        }

    }
}
