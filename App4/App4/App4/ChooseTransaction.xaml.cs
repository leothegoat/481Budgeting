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
        public ChooseTransaction()
        {
            InitializeComponent();
        }
        private async void AddDeposit_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddDeposit());
        }
        private async void AddExpenditure_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddExpenditure());
        }
    }
}