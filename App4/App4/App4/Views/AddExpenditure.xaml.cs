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
    public partial class AddExpenditure : ContentPage
    {
        UserModel user;
        public AddExpenditure(int id)
        {
            InitializeComponent();
            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                conn.CreateTable<UserModel>();
                user = conn.FindWithQuery<UserModel>("select * from UserModel where id=?", id);
            }
        }
        private void AddExpense_Clicked(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(EnteredExpense.Text) == true)
                DisplayAlert("Error", "Please Enter A Valid Amount and Selected Category", "Retry");

            else{
                Nullable<double> amount = Convert.ToDouble(EnteredExpense.Text);
                Nullable<double> category = Convert.ToDouble(CategoryPicker.SelectedIndex);
                if (category < -.01 || category > 4.1)
                    DisplayAlert("Error", "Please Enter A Valid Amount and Selected Category", "Retry");
             
                else{
                    amount = Math.Round(amount.Value, 2);
                    DisplayAlert("Added Expense", amount.ToString(), "Okay");
                    Navigation.PushAsync(new Navigation(user.Id));
                }
            }
        }
        private void Cancel_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ChooseTransaction(user.Id));
        }
    }
}