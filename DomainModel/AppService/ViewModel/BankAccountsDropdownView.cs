using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebPages.Html;

namespace DomainModel.AppService.ViewModel
{
    public class BankAccountsDropdownView
    {
        public int selectedValue { get; set; }
        public IEnumerable<SelectListItem> bankAccounts { get; set; }
    }
}