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
        }

        private async void CreateAccount_Clicked(object sender, EventArgs e)
        {
            UserModel user = new UserModel()
            {
                username = UsernameEntry.Text,
                password = PasswordEntry.Text,
                Email = EmailEntry.Text

            };
            using(SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                conn.CreateTable<UserModel>();
                int rowsAdded = conn.Insert(user);
            }
            await Navigation.PushAsync(new Navigation());
        }
    }

}