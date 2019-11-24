using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App4
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            UsernameEntry.Completed += PasswordEntry_Complete;
            PasswordEntry.Completed += Login_Clicked;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            UsernameEntry.Focus();
            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath)) {
            //    conn.DeleteAll<TransactionTable>();
            //    conn.DeleteAll<UserModel>();
            }


         }
        public void PasswordEntry_Complete(object sender, EventArgs e)
        {
            PasswordEntry.Focus();
        }

        private async void Register_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Register());
        }

        private async void Login_Clicked(object sender, EventArgs e)
        {
            UserModel user;
            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                conn.CreateTable<UserModel>();
                user = conn.FindWithQuery<UserModel>("select * from UserModel where username=?", UsernameEntry.Text);
            }
            if (String.IsNullOrWhiteSpace(UsernameEntry.Text)|| String.IsNullOrWhiteSpace(PasswordEntry.Text))
            {
                await DisplayAlert("Error", "Incorrect Username or Password", "Retry");
            }
            else if(user == null)
            {
                await DisplayAlert("Error", "Username not Found please try again or create an account!", "Retry");
            }
            else if(user.password != PasswordEntry.Text)
            {
                await DisplayAlert("Error", "Incorrect Password", "Retry");
            }
            else if(user.password == PasswordEntry.Text)
            {
                await DisplayAlert("Welcome Back!", user.username, "Ok");
                await Navigation.PushAsync(new Navigation(user.Id));
            }
            
        }
    }
}
