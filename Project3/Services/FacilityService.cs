using Project3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project3.Services
{
    public interface FacilityService
    {
        public dynamic CreateFacility(Facility facility);

        public dynamic Finds(int id);
        public void Delete(int id);
        public dynamic FindAll();

        public dynamic FindAllByHead(int id);

        public dynamic FindAllByName(string name);

        public dynamic update(Facility fa);

        public bool NameCheck(string name);

       
    }
}
