using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.Collections.ObjectModel;

namespace App4
{
    public class Database
    {
        readonly SQLiteAsyncConnection _DB;

        public Database(String dbpath)
        {
            _DB = new SQLiteAsyncConnection(dbpath);
            _DB.CreateTableAsync<UserModel>().Wait();
            _DB.CreateTableAsync<TransactionTable>().Wait();
        }

      /* public Task<List<UserModel>> GetUserAsync()
        {
            return _DB.Table<UserModel>().ToListAsync();
        }

        public Task<int> SaveUserAsync(UserModel um)
        {
            return _DB.InsertAsync(um);

        }*/
    }
}
