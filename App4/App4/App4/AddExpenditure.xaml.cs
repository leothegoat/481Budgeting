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
        public AddExpenditure()
        {
            InitializeComponent();
        }
        private void AddExpense_Clicked(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(EnteredExpense.Text) == true)
            {
                DisplayAlert("Error", "Please Enter A Valid Amount and Selected Category", "Retry");

            }
            else
            {
                Nullable<double> amount = Convert.ToDouble(EnteredExpense.Text);
                Nullable<double> category = Convert.ToDouble(CategoryPicker.SelectedIndex);
                if (amount == null || (category < -.01) || (category > 4.1))
                {
                    DisplayAlert("Error", "Please Enter A Valid Amount and Selected Category", "Retry");
                }
                else
                {
                    amount = amount.Value % 0.01;
                    string cat = CategoryPicker.SelectedItem.ToString();
                    if ((cat.Length != 0) && (amount > 0))
                    {
                        DisplayAlert("Alert", "Expense Has Been Added", "Okay");
                        Navigation.PushAsync(new Navigation());
                    }
                    else
                    {
                        DisplayAlert("Error", "Please Enter a Valid Amount with a Selected Category", "Retry");
                    }
                }
            }
        }
    }
}