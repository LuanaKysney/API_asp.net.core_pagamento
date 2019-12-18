using Microsoft.Extensions.Configuration;
using System;
using System.Reflection.Metadata;
using Zoop;
using Zoop.Services;
using Zoop.Models;
using Zoop.Helpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api_Pagamento.Models
{
    public class Json_boleto
    {
        [Key]
        public Guid Id { get; set; }

        //Representa o buyer ou seller que irá pagar o boleto
        //Pagador/CPF/CNPJ/Endereço
        [Required]
        [ForeignKey ("customerId")]
        public CustomerClient customer { get; set; }

        public Guid customerId { get; set; }


        //Caso não seja enviada uma data, o padrão é D+3.
        public DateTime expiration_date { get; set; }

        //Enviar valor em centavos
        [Required]
        public decimal amount { get; set; }

        //Informações de instruções de pagamento para o caixa
        public string body_instructions {get; set;}

        //Representa as informações do seller
        //Sacador/Avalista
        public string on_behalf_of { get; set; }
        
        public string currency { get; set; }
        public string description { get; set; }
        [Required]
        public string payment_type { get; set; }

    }
}
