using Project3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project3.Services
{
    public class AccountServiceImp : AccountService
    {

        private DatabaseContext db;

        public AccountServiceImp(DatabaseContext db)
        {
            this.db = db;
        }


        public bool Login(string username, string password)
        {
            return db.Accounts.SingleOrDefault(a => a.Username == username && a.Password == password) != null; 
        }
    }
}
