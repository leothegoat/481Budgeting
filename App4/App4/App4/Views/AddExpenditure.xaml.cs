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
            //Picker picker = sender as Picker;
            var selected = CategoryPicker.SelectedItem;
            var value = selected.ToString();

            /*TransactionTable transaction;
            transaction.amount = EnteredExpense.Text;
            transaction.type = "Exense";
            transaction.category = value;
            transaction.UserID = user.Id;*/



            if (String.IsNullOrWhiteSpace(EnteredExpense.Text) == true)
                DisplayAlert("Error", "Please Enter A Valid Amount and Selected Category", "Retry");

            else{
                Nullable<double> amountEx = Convert.ToDouble(EnteredExpense.Text);
                Nullable<double> category = Convert.ToDouble(CategoryPicker.SelectedIndex);
                if (category < -.01 || category > 4.1)
                    DisplayAlert("Error", "Please Enter A Valid Amount and Selected Category", "Retry");
             
                else{
                   // Nullable<double> amount = Convert.ToDouble(EnteredExpense.Tex);
                    amountEx = Math.Round(amountEx.Value, 2);
                    //TransactionTable transaction;
                    /*transaction.amount = Convert.ToDouble(amount); 
                    transaction.type = "Exense";
                    transaction.category = value;
                    transaction.UserID = user.Id;*/
                    TransactionTable transaction = new TransactionTable()
                    {
                        amount = Convert.ToDouble(amountEx),
                        type = "Expense",
                        category = value,
                        UserID = user.Id,
                        //shit = "Type: " + value + " Category: Expense",

                    };
                    transaction.shit = "Type: "+ transaction.type+"        Category: "+ transaction.category;
                    using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
                    {
                        conn.CreateTable<TransactionTable>();
                        conn.Insert(transaction);
                    }
                   
                    DisplayAlert("Added Expense", amountEx.ToString(), "Okay");
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