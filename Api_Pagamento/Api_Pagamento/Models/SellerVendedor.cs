using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Pagamento.Models
{
    public class SellerVendedor
    {
        [Key]
        public Guid id { get; set; }
        public string resource { get; set; }
        //Um número de identificação do contribuinte é usado para registrar e acompanhar os pagamentos de impostos.
        public string taxpayer_id { get; set; }
        public enum type { individual, business} 
        public string description { get; set; } 
        public string first_name { get; set; }
        public string last_name  { get; set; }
        public string email { get; set; }
        public string phone_number { get; set; }
        //Código de 4 dígitos designado por uma empresa de cartão de crédito que lista o produto,
        //serviço ou linha de negócios de um comerciante
        public int mcc { get; set; }
        public string birthdate { get; set; }
        public string facebook { get; set; }
        public string twitter { get; set; }
        //CNPJ do Vendendor
        public string ein { get; set; }

        [ForeignKey("addressId")]
        public AddressClient address { get; set; }
        public Guid addressId { get; set; }

        public string default_debit { get; set; }
        public string default_credit { get; set; }
        public bool show_profile_online { get; set; }
        //W3C Datetime Format para a criação da data (yyyy-mm-ddThh:mm:ssZ)
        public string created_at { get; set; }
        //W3C Datetime Format para a última atualização (yyyy-mm-ddThh:mm:ssZ)
        public string updated_at { get; set; }



    }
}
