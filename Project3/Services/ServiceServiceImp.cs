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

        public dynamic Create(Service service)
        {
            if (Check(service.Id, service.Name))
            {
                return null;
            }
            else
            {
                db.Services.Add(service);
                db.SaveChanges();
                return service;
            }
        }

        public bool Check(int id, string name)
        {
            return db.Services.Count(c => c.FacilityId == id && c.Name == name) > 0;
        }

        public void delete(int id)
        {
            db.Services.Remove(db.Services.Find(id));
            db.SaveChanges();
        }

        public dynamic find(int id)
        {
            try
            {
                IQueryable<Service> a = db.Services.Where(x => x.Id == id);
                if (a.Sum(x => x.Id) == 0)
                    return null;

                return a.Select(x => new
                {
                    id = x.Id,
                    name = x.Name,
                    facility = new
                    {
                        id = x.Facility.Id,
                        name = x.Facility.Name
                    },
                    description = x.Description
                });

            }
            catch
            {
                return null;
            }
        }

        public dynamic FindAll()
        {
            return db.Services.Select(x => new
            {
                id = x.Id,
                name = x.Name,
                facility = new
                {
                    id = x.Facility.Id,
                    name = x.Facility.Name
                },
                description = x.Description
            }).ToList();
        }

        public dynamic update(Service ac)
        {
            try
            {
                IQueryable<Service> a = db.Services.Where(x => x.Id == ac.Id);
                if (a.Sum(x => x.Id) == 0)
                    return false;

                db.Entry(ac).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return null;
            }
        }
    }
}
