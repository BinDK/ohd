using Project3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project3.Services
{
    public interface AdminService
    {
        public dynamic listAccount();
        public dynamic listRole();
        public dynamic addAccount(Account account);
        public dynamic findAccount(int id);
        public dynamic Finds(int id);
        public void deleteAccount(int id);
        public dynamic updateAccount(Account ac);
        public dynamic Check(string username, string email);
        public dynamic FindAllHead();
    }
}
