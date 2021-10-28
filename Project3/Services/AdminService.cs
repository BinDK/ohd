using Project3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project3.Services
{
   public interface AdminService
    {
        dynamic listAccount();
        dynamic listRole();
        public dynamic addAccount(Account account);
<<<<<<< HEAD
        dynamic findAccount(int id);
=======
        public dynamic Finds(int id);
        public void deleteAccount(int id);

>>>>>>> 35e2ee384c9c38a0855a02bd667f2bbfdeef6c69
    }
}
