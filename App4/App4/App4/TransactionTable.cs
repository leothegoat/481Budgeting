using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;
using Xamarin.Forms;

namespace App4
{
    class TransactionTable
    {
        [PrimaryKey, AutoIncrement]
        public int Tid { get; set; }
        public double amount { get; set; }
        public string type { get; set; } //Dep or Exp
        public int UserID { get; set; }
        //public string date { get; set; }
        public string category { get; set; } //Cat for Deposit will be "Deposit"
        public string description { get; set; } //Gives a description of purchase (Expense only)
    }
}