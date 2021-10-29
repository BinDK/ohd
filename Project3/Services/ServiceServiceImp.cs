using Microsoft.Extensions.Configuration;
using Project3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project3.Services
{
    public class ServiceServiceImp : ServiceService
    {

        private DatabaseContext db;
        public ServiceServiceImp(DatabaseContext db)
        {
            this.db = db;
        }

    }
}
