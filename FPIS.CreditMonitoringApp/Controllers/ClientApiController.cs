using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FPIS.CreditMonitoringApp.Models.RequestModels;
using FPIS.CreditMonitoringApp.Models.ResponseModels;
using FPIS.Entities;
using FPIS.ServiceEntities.ClientService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FPIS.CreditMonitoringApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientApiController : ControllerBase
    {
        private readonly IClientFacade _clientFacade;       

        public ClientApiController(IClientFacade clientFacade)
        {
            this._clientFacade = clientFacade;
        }

        //POST: api/ClientApi/create
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> InsertAsync([FromBody]ClientRequestModel data)
        {
            JsonResult result;
            ClientResponseModel response = new ClientResponseModel();

            Klijent newClient = new Klijent { BrojRacuna = long.Parse(data.BrojRacuna), AdresaISediste= data.AdresaISediste, ImeIPrezimeKlijenta= data.ImeIPrezimeKlijenta, PIB= long.Parse(data.PIB) };

            bool insertedClient = await _clientFacade.InsertAsync(newClient);
            if(!insertedClient)
            {
                response.Message = "Insert failed!";
                result = new JsonResult(response);

                return BadRequest(result);
            }

            response.Message = "Client inserted successfully!";
            result = new JsonResult(response);

            return result;
        }
    }
}