using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DarkIce
{
    public class AccountList : List<Account>
    {
        public string Heading { get; set; }
        public List<Account> GroupedAccounts => this;
    }
}