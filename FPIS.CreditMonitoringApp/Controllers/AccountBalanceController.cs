using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FPIS.CreditMonitoringApp.Models;
using FPIS.Entities;
using FPIS.ServiceEntities;
using FPIS.ServiceEntities.AccountBalanceService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FPIS.CreditMonitoringApp.Controllers
{
    public class AccountBalanceController : Controller
    {
        private ILogger<AccountBalanceController> _logger;
        private readonly IAccountBalanceFacade _accountBalanceFacade;
        private readonly IAccountFacade _accountFacade;
        private static List<Stanje> _newAccountBalances = new List<Stanje>();

        public AccountBalanceController(ILogger<AccountBalanceController> logger, IAccountBalanceFacade accountBalanceFacade, IAccountFacade accountFacade)
        {
            this._logger = logger;
            this._accountBalanceFacade = accountBalanceFacade;
            this._accountFacade = accountFacade;
        }

        public async Task<IActionResult> Index()
        {
            _newAccountBalances.Clear();

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            AccountBalanceViewModel accountBalanceViewModel = new AccountBalanceViewModel();
            var accounts = await _accountFacade.GetAll();

            foreach (var account in accounts)
                accountBalanceViewModel.AccountTypes.Add(account.TipRacuna);

            return View(accountBalanceViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AccountBalanceViewModel accountBalanceViewModel)
        {
            foreach (var accountBalance in _newAccountBalances)
            {
                var entity = await _accountBalanceFacade.InsertAsync(accountBalance);
            }

            _newAccountBalances.Clear();
            return View("Index");
        }

        /*[HttpGet]
        public async Task<IActionResult> Edit(long id)
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit()
        {

        }*/

        public async Task<IActionResult> Delete(long id)
        {
            await _accountBalanceFacade.DeleteAsync(id);

            return View("Index");
        }

        [HttpGet]
        public async Task<IActionResult> GetAccount(long accId, string accType)
        {
            var findedAccount = await _accountFacade.GetByIdAndTypeAsync(accId, accType);

            //TODO: pronaci racun po id-u i tipu
            if (findedAccount == null)
                return BadRequest("Ne postoji trazeni racun!");

            return Json("Racun uspjesno pronadjen!");
        }

        [HttpGet]
        public async Task<IActionResult> AddNewAccountBalance(long accId, double accBalance)
        {
            if (ModelState.IsValid)
            {
                var newAccountBalance = new Stanje() { BrojRacuna = accId, IznosStanja = accBalance };
                _newAccountBalances.Add(newAccountBalance);

                return Json(_newAccountBalances.Select(x => new
                {
                    IznosStanja = x.IznosStanja
                }));
            }

            return BadRequest("Validacija nije prosla!");
        }
    }
}