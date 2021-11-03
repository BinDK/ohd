using Project3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project3.Services
{
    public interface ServiceService
    {
        void delete(int id);
        dynamic find(int id);
        dynamic update(Service ac);

        dynamic Create(Service service);

        bool Check(int id, string name);
    }
}
