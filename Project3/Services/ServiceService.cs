using Project3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project3.Services
{
    public interface ServiceService
    {
        public void delete(int id);
        public dynamic find(int id);

        public dynamic FindAll();
        public dynamic update(Service ac);

        public dynamic Create(Service service);

        public bool Check(int id, string name);

        public dynamic findBaseFacility(int idFaci);
    }
}
