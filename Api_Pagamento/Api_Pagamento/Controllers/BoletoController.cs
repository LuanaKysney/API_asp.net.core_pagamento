using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api_Pagamento.Controllers
{
    [Route("api/boleto")]
    [ApiController]
    public class BoletoController : ControllerBase
    {
        //Chamar meu banco
        private readonly Data.DataContext _dataContext;
        public BoletoController(Data.DataContext dataContext)
        {
            //Receber meus dados do banco
            _dataContext = dataContext;
        }
        //App ---- /api/boleto
        [Route("")]
        [HttpGet]
        public ActionResult GetAllBoletos()
        {
            return new JsonResult(_dataContext.json_Boletos);
        }
        //App ---- /api/boleto/22
        [Route("{id}")]
        [HttpGet]
        public ActionResult GetBoleto(int id)
        {
            return Ok(_dataContext.json_Boletos.Find(id));
        }
        [Route("")]
        [HttpPost]
        public ActionResult GerarBoleto (Models.Json_boleto json_Boleto)
        {
            _dataContext.json_Boletos.Add(json_Boleto);
            return Ok();
        }
        [Route("{id}")]
        [HttpPut]
        public ActionResult Atualizar (Guid id, Models.Json_boleto json_Boleto)
        {
            json_Boleto.Id = id;
            _dataContext.json_Boletos.Update(json_Boleto);

            return Ok();
        }
        [Route("{id}")]
        [HttpDelete]
        public ActionResult Deletar (int id)
        {
            _dataContext.json_Boletos.Remove(_dataContext.json_Boletos.Find(id));
            
            return Ok();
        }
    }
}