using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace DarkIce
{
    public partial class AccountDetail : ContentPage
    {
        private Account selectedAccount;

        public AccountDetail()
        {
            InitializeComponent();
            BindingContext = this;
        }

        public AccountDetail(Account selectedAccount)
        {
            this.selectedAccount = selectedAccount;
        }

        //protected override void OnAppearing()
        //{
        //    Console.WriteLine("Welcome");
        //    Console.WriteLine(selectedAccount.Name.FullName);
        //}
    }
}
