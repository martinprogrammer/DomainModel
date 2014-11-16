using DomainModel.AppService;
using DomainModel.AppService.Messages;
using DomainModel.AppService.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DomainModel.Controllers
{
    public class BankAccountController : Controller
    {

        ApplicationBankAccountService myService = new ApplicationBankAccountService();
        // GET: BankAccount
        public ActionResult Index()
        {
            IEnumerable<BankAccountView> result = myService.GetAllBankAccounts().BankAccountView;
            return View(result);
        }

        [HttpGet]
        public ActionResult Edit(string acc)
        {
            BankAccountsDropdownView theView = myService.GetAccountsDropdown(acc);
            theView.selectedValue = 1;

            return View(theView);
        }
    }
}