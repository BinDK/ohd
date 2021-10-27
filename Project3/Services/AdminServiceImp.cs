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

        public dynamic listAccount()
        {
            return db.Accounts.ToList().Select(x => new
            {
               id = x.Id,name= x.Name,
email = x.Email,
                username = x.Username,role = new {id = x.Role.Id,name = x.Role.Name},
status = x.Status

            });
        }
        
        public dynamic listRole()
        {
            return db.Roles.ToList().Select(x => new
            {
                id = x.Id,name= x.Name
            });
        }

        public dynamic addAccount(Account account)
        {
            db.Accounts.Add(account);
            db.SaveChanges();
            return account;
        }
    }
}
