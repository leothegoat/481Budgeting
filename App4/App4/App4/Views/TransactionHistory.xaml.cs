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
        public TransactionHistory()
        {
            InitializeComponent();
        }
        private async void Navigation_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Navigation());
        }
       
    }
}
