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
        dynamic findAccount(int id);
    }
}
