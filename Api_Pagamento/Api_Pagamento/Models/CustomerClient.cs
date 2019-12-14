using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Pagamento.Models
{
    //Classe representa o usuário que vai ser debitado
    public class CustomerClient
    {
            [Key]
            public Guid Id { get; set; }
       
            [Required]
            public string first_name { get; set; }

            //CPF ou CNPJ do comprador
            [Required]
            [MaxLength (20)]
            public string taxpayer_id { get; set; }

            public string email { get; set; }

            [Required]
            [ForeignKey ("addressId")]
            public AddressClient address { get; set; }
            public Guid addressId { get; set; }




        //public class transacao
        //{
        //    string uri = "https://api.zoop.ws/v1/marketplaces/:marketplace_id/buyers";
        //}

    }
}
