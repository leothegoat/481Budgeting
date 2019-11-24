using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Entry = Microcharts.Entry;

namespace App4
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OverviewPage : ContentPage
    {
        UserModel user;
        Account acc;
        
        public OverviewPage(int id)
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
            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                conn.CreateTable<Account>();
                acc = conn.FindWithQuery<Account>("select * from Account where uId=?", user.Id);
            }
            List<Entry> entries = new List<Entry>
            {
                
                new Entry((float)acc.billSpent)
                {
                    Color = SkiaSharp.SKColor.Parse("#ff0000"),
                    ValueLabel="$"+Convert.ToString(acc.billSpent),
                    Label = "Bills",
                    TextColor = SkiaSharp.SKColor.Parse("#ffffff")
                },
                new Entry((float)acc.entSpent)
                {
                    Color = SkiaSharp.SKColor.Parse("#008000"),
                    ValueLabel="$"+Convert.ToString(acc.entSpent),
                    Label = "Entertainment",
                    TextColor = SkiaSharp.SKColor.Parse("#ffffff")
                },

                new Entry((float)acc.tranSpent)
                {
                    Color = SkiaSharp.SKColor.Parse("#800080"),
                    ValueLabel="$"+Convert.ToString(acc.tranSpent),
                    Label = "Transportation",
                    TextColor = SkiaSharp.SKColor.Parse("#ffffff")
                },

                new Entry((float)acc.otherSpent)
                {
                    Color = SkiaSharp.SKColor.Parse("#ff8c00"),
                    ValueLabel="$"+Convert.ToString(acc.otherSpent),
                    Label = "Other",
                    TextColor = SkiaSharp.SKColor.Parse("#ffffff")
                },
                
                new Entry((float)acc.foodSpent)
                {
                    Color = SkiaSharp.SKColor.Parse("#ffff00"),
                    ValueLabel="$"+Convert.ToString(acc.foodSpent),
                    Label = "Food",
                    TextColor = SkiaSharp.SKColor.Parse("#ffffff")
                }
            };

            Chart1.Chart = new Microcharts.DonutChart {
                Entries = entries,
                BackgroundColor = SkiaSharp.SKColor.Parse("#000080"),
                LabelTextSize = 25,
                HoleRadius = .8f,
                Margin = 35,          
            };
        }
            private async void Navigation_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Navigation(user.Id));
        }
        
        private async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Navigation(user.Id));
        }
    }
}