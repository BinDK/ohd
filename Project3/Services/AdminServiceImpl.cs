using Project3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project3.Services
{
    public class AdminServiceImpl : AdminService
    {
        private DatabaseContext db;
        public AdminService(DatabaseContext _db)
        {
            db = _db;
        }


        public dynamic addAccount(Account account)
        {
            db.Accounts.Add(account);
            db.SaveChanges();
            return account;
        }

        public dynamic listAccount(string key, int page, int roleId)
        {
            throw new NotImplementedException();
        }
    }
}
