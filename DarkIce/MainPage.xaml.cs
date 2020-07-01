using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DarkIce
{
    public partial class MainPage : ContentPage
    {
        public List<Account> Accounts { get; set; }
        public List<Account> FemaleAccounts { get; set; }
        public List<Account> MaleAccounts { get; set; }
        private List<AccountList> _listOfAccounts;
        public List<AccountList> ListOfAccounts {  get { return _listOfAccounts; } set { _listOfAccounts = value; base.OnPropertyChanged(); } }

        RestService _restService;

        public MainPage()
        {
            InitializeComponent();
            _restService = new RestService();
        }

        protected async void OnListViewItemSelected(System.Object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            Account selectedAccount = e.SelectedItem as Account;
            await Navigation.PushAsync(new AccountDetail(selectedAccount));
        }

        void OnListViewItemTapped(object sender, ItemTappedEventArgs e)
        {
            Account tappedItem = e.Item as Account;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            Accounts = await _restService.GetAccountAsync(Constants.ApiEndpoint);
            SortAndFilter();

            var femaleList = new AccountList();
                foreach (var account in FemaleAccounts)
            {
                femaleList.Add(new Account() { IsActive = account.IsActive, AccountBalance = account.AccountBalance, Age = account.Age, EyeColor = account.EyeColor, Gender = account.Gender, Name = new Name() { First = account.Name.First, Last = account.Name.Last }, Picture = account.Picture, Registered = account.Registered });
            }
            femaleList.Heading = "Female";

            var maleList = new AccountList();
            foreach (var account in MaleAccounts)
            {
                maleList.Add(new Account() { IsActive = account.IsActive, AccountBalance = account.AccountBalance, Age = account.Age, EyeColor = account.EyeColor, Gender = account.Gender, Name = new Name() { First = account.Name.First, Last = account.Name.Last }, Picture = account.Picture, Registered = account.Registered });
            }

            maleList.Heading = "Male";

            var list = new List<AccountList>()
            {
                femaleList,
                maleList
            };

            ListOfAccounts = list;

            BindingContext = this;

        }

        public void SortAndFilter()
        {
            Accounts = Accounts.Where(a => a.IsActive && a.IsRecent).ToList();
            Accounts = Accounts.OrderByDescending(a => a.Age).ThenBy(a => a.AccountBalance).ToList();
            FemaleAccounts = Accounts.Where(a => a.Gender == "female").ToList();
            MaleAccounts = Accounts.Where(a => a.Gender == "male").ToList();
        }
    }
}
