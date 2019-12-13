using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api_Pagamento.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PagamentoController : ControllerBase
    {
        //[HttpGet]
        //[Route("")]
        //public async Task<ActionResult<List<Models.CustomerClient>>> Get ([FromServices] Data.DataContext context)
        //{
        //    var comprador = await context.customerClients.to

        //    return comprador;
        //}

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
        public async Task<ActionResult<Models.CustomerClient>> CriarComprador()
        {
            var a = true;
            
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
         
            
            
            return deserializedCustomer;

        }
    }
}