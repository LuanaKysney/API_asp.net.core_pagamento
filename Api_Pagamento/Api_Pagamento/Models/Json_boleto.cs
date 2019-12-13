using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace Api_Pagamento.Models
{
    public class Json_boleto
    {
        //Representa o buyer ou seller que irá pagar o boleto
        //Pagador/CPF/CNPJ/Endereço
        public string customer { get; set; }

        //Caso não seja enviada uma data, o padrão é D+3.
        public DateTime expiration_date { get; set; }

        //Enviar valor em centavos
        public decimal amount { get; set; }

        //Informações de instruções de pagamento para o caixa
        public string body_instructions {get; set;}

        //Representa as informações do seller
        //Sacador/Avalista
        public string on_behalf_of { get; set; }

        public string currency { get; set; }
        public string description { get; set; }
        public string payment_type { get; set; }


        private IConfiguration _configuration;
        public void GerenciarZoopConecxao(IConfiguration configuration)
        {
            //Armazenando minha instancia
            _configuration = configuration;

        }
        public void GerarBoleto( /*decimal valor*/)
        {
            string marketplace_id = _configuration.GetValue<String>("Pagamento:Zoop:Marketplace_id");
            string publishable_key = _configuration.GetValue<String>("Pagamento:Zoop:publishable_key");

            amount = 300;
            currency = "BRL";
            description = "Venda";
            on_behalf_of = "573e2aa71cb94ecda8dee14087327b48";
            customer = "573e2aa71cb94ecda8dee14087327b48";
            payment_type = "boleto";
        }

    }
}
