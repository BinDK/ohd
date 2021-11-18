using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project3.Services
{
    public interface AccountService
    {
        public bool Login(string username, string password);
    }
}
