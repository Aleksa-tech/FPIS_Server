using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FPIS.CreditMonitoringApp.Models;
using FPIS.Entities;
using FPIS.ServiceEntities;
using FPIS.ServiceEntities.ClientService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FPIS.CreditMonitoringApp.Controllers
{
    public class ClientsController : Controller
    {
        private ILogger<ClientsController> _logger;
        private readonly IClientFacade _clientFacade;
        private readonly IAccountFacade _accountFacade;

        public ClientsController(ILogger<ClientsController> logger, IClientFacade clientFacade, IAccountFacade accountFacade)
        {
            this._logger = logger;
            this._clientFacade = clientFacade;
            this._accountFacade = accountFacade;
        }

        public async Task<IActionResult> Index()
        {

            IEnumerable<Klijent> clients = await _clientFacade.GetAll();

            return View(clients);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(long id)
        {
            var client = await _clientFacade.GetById(id);

            if (client == null)
                return View("~/Views/Shared/Error.cshtml", new ErrorViewModel() { });

            var clientViewModel = new ClientViewModel { Client = client };
            return View(clientViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ClientViewModel clientViewModel)
        {
            var client = clientViewModel.Client;

            var updatedClient = await _clientFacade.UpdateAsync(client);
            if (updatedClient)
                return View("Index", await _clientFacade.GetAll());
            ViewBag.Message = "Error! Try again!";

            return View("Edit", clientViewModel);
        }

        
        public async Task<IActionResult> Delete(long id)
        {
            await _clientFacade.DeleteAsync(id);

            return View("Index", await _clientFacade.GetAll());
        }
    }
}