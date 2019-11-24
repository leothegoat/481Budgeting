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
    public partial class TransactionHistory : ContentPage
    {
        UserModel user;
        public TransactionHistory(int id)
        {
            InitializeComponent();
            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                conn.CreateTable<UserModel>();
                user = conn.FindWithQuery<UserModel>("select * from UserModel where id=?", id);
            }
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                conn.CreateTable<TransactionTable>();
                List<TransactionTable> p = new List<TransactionTable>();
                var tranactions = conn.Table<TransactionTable>().ToList();
                foreach(TransactionTable item in tranactions)
                {
                    if (item.UserID == user.Id)
                        p.Add(item);  
                }
                UsernameListView.ItemsSource = p;
            }
        }
        private async void Navigation_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Navigation(user.Id));
        }
       
    }
}
