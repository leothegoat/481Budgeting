using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace App4
{
    class UserModel
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string Email { get; set; }

    }
}
