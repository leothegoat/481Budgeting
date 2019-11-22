using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;
using Xamarin.Forms;

namespace App4
{
    class Account
    {
        [PrimaryKey, AutoIncrement]
        public int Aid { set; get; }
        public double dep { set; get; }
        public double bal { set; get; }
        public double spent { set; get; }
        public double foodSpent { set; get; }
        public double entSpent { set; get; }
        public double tranSpent { set; get; }
        public double billSpent { set; get; }
        public double otherSpent { set; get; }
        public int uId { set; get; }
    }
}
