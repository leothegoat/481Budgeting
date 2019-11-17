﻿using System;
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
            if (check == null) {
                    using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
                    {
                        conn.CreateTable<UserModel>();
                        conn.Insert(user);
                    }
                    await DisplayAlert("Account Created for ", user.username, "Ok");
                    await Navigation.PushAsync(new Navigation(user.Id));
                
             }
            else
                await DisplayAlert("Alert", "User already exists please cancel or use another username.", "OK");
            
        }
        private async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
    }

}