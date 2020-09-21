using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FPIS.CreditMonitoringApp.Models.ResponseModels;
using FPIS.Entities;
using FPIS.ServiceEntities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FPIS.CreditMonitoringApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountApiController : ControllerBase
    {
        private readonly IAccountFacade _accountFacade;

        public AccountApiController(IAccountFacade accountFacade)
        {
            this._accountFacade = accountFacade;
        }

        //GET: api/AccountApi/accounts
        [HttpGet]
        [Route("accounts")]
        public async Task<IActionResult> GetAccountsAsync()
        {
            JsonResult result;
            AccountResponseModel response = new AccountResponseModel();
            List<Racun> accounts = await _accountFacade.GetAll();

            if (accounts == null)
            {
                response.Message = "Not found! Try again!";
                result = new JsonResult(response);

                return NotFound(result);
            }

            response.Message = "Successfully read accounts!";
            response.Accounts = accounts;
            result = new JsonResult(response);

            return result;
        }
    }
}