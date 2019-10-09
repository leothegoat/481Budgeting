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
        public Navigation()
        {
            InitializeComponent();
        }

        internal static Task PushAsync(Navigation navigation)
        {
            throw new NotImplementedException();
        }

        private async void Choose_Transaction_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ChooseTransaction());
        }

        /*private async void expense_graph(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ());
        }*/

    }
}






