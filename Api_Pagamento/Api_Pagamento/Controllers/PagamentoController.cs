using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Xml;
using Api_Pagamento.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api_Pagamento.Controllers
{
    [Route("api/pagamento")]
    [ApiController]

    public class PagamentoController : ControllerBase
    {
        private readonly Services.ICustomerClient _customerClient;
        private readonly IMapper _mapper;


        [HttpPost]
        [Route ("")]
        public async Task<ActionResult<Models.Json_boleto>> Post (
            [FromServices] Data.DataContext context,
            [FromBody] Models.Json_boleto json_Boleto_model)
        {
            if (ModelState.IsValid) {

                context.Add(json_Boleto_model);
                await context.SaveChangesAsync();
                return json_Boleto_model;
            }
            else {
                return BadRequest(ModelState);
            }
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Models.CustomerClient>> PostCriarComprador()
        {
            string uri = @"https://api.zoop.ws/v1/marketplaces/19c7b44ebce4413f8b1ed846aa43d768/buyers";

            //Paramentros 
            System.Collections.Specialized.NameValueCollection postDados = new System.Collections.Specialized.NameValueCollection();
            postDados.Add("first_name", "Goku Super Sayajin");
            postDados.Add("taxpayer_id", "27773053073");
            postDados.Add("email", "testeApi@teste.com");
            postDados.Add("currency", "BRL");
            postDados.Add("address", ""); 
            postDados.Add("neighborhood", "Barra da Tijuca"); 
            postDados.Add("city", "Rio de Janeiro");
            postDados.Add("state", "RJ");
            postDados.Add("postal_code", "22845046");
           postDados.Add("country_code", "BR");

            //Receberá o json de retorno
            string json_result = null;

            using (WebClient webClient = new WebClient()) {
                //informa o header sobre url
                webClient.Headers[HttpRequestHeader.ContentType] = "application/json";

                //Faz o post e retorna o json, contendo a resposta do servidor da Zoop
                var result = webClient.UploadValues(uri, postDados);

                //Obtem string do Json
                json_result = System.Text.Encoding.ASCII.GetString(result);
            }
            //Criando meu Json
            string output = Newtonsoft.Json.JsonConvert.SerializeObject(postDados);

            //Deserealizando o Json
            Models.CustomerClient deserializedCustomer = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.CustomerClient>(output);

            //Obter token
            //var token = output.GetHashCode("code")[0];

            //Url para pagamento
            string pagamentoUrl = string.Concat (@"https://api.zoop.ws/v1/marketplaces/19c7b44ebce4413f8b1ed846aa43d768/buyers");
         
            
            
            return Ok();

        }
        [HttpGet]
        [Route ("")]
        public ActionResult GetVendedor()
        {
            SellerVendedor sellerVendedor = new SellerVendedor();

            string uri = "https://api.zoop.ws/v1/marketplaces/19c7b44ebce4413f8b1ed846aa43d768/sellers";


            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<Models.Json_boleto>> PostTransacaoBoleto([FromBody] Models.Json_boleto json_Boleto )
        {
            CustomerClient customerClient = new CustomerClient();
            string url = @"https://api.zoop.ws/v1/marketplaces/19c7b44ebce4413f8b1ed846aa43d768/transactions";
            
            System.Collections.Specialized.NameValueCollection postDados = new System.Collections.Specialized.NameValueCollection();
            postDados.Add("first_name", "Goku Super Sayajin");
            postDados.Add("taxpayer_id", "27773053073");
            postDados.Add("email", "testeApi@teste.com");
            postDados.Add("currency", "BRL");
            postDados.Add("address", "");
            postDados.Add("neighborhood", "Barra da Tijuca");
            postDados.Add("city", "Rio de Janeiro");
            postDados.Add("state", "RJ");
            postDados.Add("postal_code", "22845046");
            postDados.Add("country_code", "BR");
            json_Boleto.amount = 30;
            json_Boleto.currency = "brl";
            json_Boleto.on_behalf_of = "Celso";
            json_Boleto.payment_type = "boleto";
            json_Boleto.customer = customerClient;
            
           using (WebClient webClient = new WebClient())
            {
                webClient.Headers[HttpRequestHeader.ContentType] = "application/json";
                webClient.Headers[HttpRequestHeader.Authorization] = "zpk_test_fjeuGSGMEgTbIqyv74nsUkpd";
                
            }


            return Ok("Processado");
        }

        [HttpPost]
        public ActionResult<Models.Json_boleto> CreateBoletoForCustomer(
            Guid customerId, JsonForCreationDto boleto)
        {
            if (!_customerClient.CustomerExists(customerId))
            {
                return NotFound();
            }

            var courseEntity = _mapper.Map<Models.Json_boleto>(boleto);
            _customerClient.AddJson_boleto(customerId, courseEntity);
            _customerClient.Save();

            var courseToReturn = _mapper.Map<Data.DataContext>(courseEntity);
            return CreatedAtRoute("GetBoletoForCustomer",
                new { authorId = customerId, courseId = courseToReturn.ContextId },
                courseToReturn);
        }
<<<<<<< HEAD
        //[HttpPost]
        //public async Task<ActionResult<Models.Json_boleto>> TransacaoBoleto()
        //{
        //    var boleto = "";
        //    //Criar uma nova transação de boleto através do serviço de pagamentos associando 
        //    //    o comprador e o vendedor da sua plataforma, encaminhando o boleto gerado para
        //    //    o comprador realizar o pagamento dentro do prazo determinado.
        //string boletoUrl = transaction.BoletoUrl;
       // string boletoBarcode = transaction.BoletoBarcode;
        //    return ;
        //}
=======
>>>>>>> 57df1eac00ed38f0b3e804686c33f43dbc48faa5
    }
}