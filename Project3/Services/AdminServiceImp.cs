using Microsoft.Extensions.Configuration;
using Project3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project3.Services
{
    public class AdminServiceImp : AdminService
    {
        private IConfiguration conf;
       private DatabaseContext db;
       public AdminServiceImp (DatabaseContext db)
        {
            this.db = db;
        }

        public dynamic listAccount(string username, int page, string name, string email, string role)
        {
            try
            {
         
                    return null;
            }
            catch
            {
                return null;
            }
        }

        public dynamic listRole()
        {
            return db.Roles.ToList();
        }

        public dynamic addAccount(Account account)
        {
            db.Accounts.Add(account);
            db.SaveChanges();
            return account;
        }
    }
}
