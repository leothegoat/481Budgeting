using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App4
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChooseTransaction : ContentPage
    {
        UserModel user;
        public ChooseTransaction(int id)
        {
            InitializeComponent();
            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                conn.CreateTable<UserModel>();
                user = conn.FindWithQuery<UserModel>("select * from UserModel where id=?", id);
            }
        }
        private async void AddDeposit_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddDeposit(user.Id));
        }
        private async void AddExpenditure_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddExpenditure(user.Id));
        }
        private async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Navigation(user.Id));
        }
    }
}