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

    public partial class Navigation : ContentPage
    {
        UserModel user;
        public Navigation(int id)
        {
            InitializeComponent();
            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                conn.CreateTable<UserModel>();
                user = conn.FindWithQuery<UserModel>("select * from UserModel where id=?", id);
            }
        }

        internal static Task PushAsync(Navigation navigation)
        {
            throw new NotImplementedException();
        }

        private async void Overview_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new OverviewPage(user.Id));
        }
        private async void Choose_Transaction_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ChooseTransaction(user.Id));
        }

        private async void TransactionHistory_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TransactionHistory(user.Id));
        }

        private async void LogOut_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }

    }
}






