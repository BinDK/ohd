using Project3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project3.Services
{
    public class AdminServiceImp : AdminService
    {
        private DatabaseContext db;
       public AdminServiceImp (DatabaseContext db)
        {
            this.db = db;
        }

        public dynamic listAccount(string username, int page, string name, string email, string role)
        {
            throw new NotImplementedException();
        }

        public dynamic listRole()
        {
            return db.Roles.ToList();
        }
    }
}
