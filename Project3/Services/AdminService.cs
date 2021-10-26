using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project3.Services
{
   public interface AdminService
    {
        dynamic listAccount(string username, int page, string name, string email, string role);
    }
}
