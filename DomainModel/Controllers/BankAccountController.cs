using DomainModel.AppService;
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
    }
}