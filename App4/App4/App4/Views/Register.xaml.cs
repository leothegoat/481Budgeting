using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace App4
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Register : ContentPage
    {
        public Register()
        {
            InitializeComponent();
            
            EmailEntry.Completed += UsernameEntry_Completed;
            UsernameEntry.Completed += PasswordEntry_Completed;
            PasswordEntry.Completed += CreateAccount_Clicked;
        }
        public void PasswordEntry_Completed(object sender, EventArgs e)
        {
            PasswordEntry.Focus();
        }
        public void UsernameEntry_Completed(object sender, EventArgs e)
        {
            UsernameEntry.Focus();
        }

        private async void CreateAccount_Clicked(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(EmailEntry.Text) == true)
                await DisplayAlert("Error", "Please Enter an Email", "Retry");
            else if (String.IsNullOrWhiteSpace(UsernameEntry.Text) == true)
                await DisplayAlert("Error", "Please Enter a Username", "Retry");
            else if (String.IsNullOrWhiteSpace(PasswordEntry.Text) == true)
                await DisplayAlert("Error", "Please Enter a Password", "Retry");
            else
            {
                UserModel user = new UserModel()
                {
                    username = UsernameEntry.Text,
                    password = PasswordEntry.Text,
                    Email = EmailEntry.Text

                };
                UserModel check;
                using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
                {
                    conn.CreateTable<UserModel>();
                    check = conn.FindWithQuery<UserModel>("select * from UserModel where username=?", user.username);

                }
                if (check == null)
                {
                    using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
                    {
                        conn.CreateTable<UserModel>();
                        conn.Insert(user);
                    }
                    Account account = new Account()
                    {
                        dep = 0, //money going in
                        bal = 0, // deposit - spent
                        spent = 0, // total spent, money going out
                        foodSpent = 0,
                        entSpent = 0,
                        tranSpent = 0,
                        billSpent = 0,
                        otherSpent = 0,
                        uId = user.Id
                    };
                    using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
                    {
                        conn.CreateTable<Account>();
                        conn.Insert(account);
                    }
                    await DisplayAlert("Account Created for ", user.username, "Ok");
                    await Navigation.PushAsync(new Navigation(user.Id));

                }
                else
                    await DisplayAlert("Alert", "User already exists please cancel or use another username.", "OK");
            }
        }
        private async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
    }

}