using Project3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project3.Services
{
    public interface PriorityService
    {
        public dynamic CreatePriority(RequestPriority requestPriority);

        public dynamic FindAll();

        public dynamic Finds(int id);

        public dynamic updatePriority(RequestPriority requestPriority);

        public void deletePriority(int id);

    }
}
