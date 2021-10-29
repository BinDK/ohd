using Microsoft.Extensions.Configuration;
using Project3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project3.Services
{
    public class FacilityServiceImp : FacilityService
    {

        private DatabaseContext db;
        public FacilityServiceImp(DatabaseContext db)
        {
            this.db = db;
        }

 public dynamic FindAll()
        {

            return db.Facilities.ToList().Select(f => new
            {
                id = f.Id,
                name = f.Name,
                head = new
                {
                    id = f.HeadAccount.Id,
                    name = f.HeadAccount.Name
                },
                description = f.Description
              
            });
        }

        public dynamic CreateFacility(Facility facility)
        {
            db.Facilities.Add(facility);
            db.SaveChanges();
            return facility;
        }


        public dynamic Finds(int id)
        {
            return db.Accounts.Select(a => new
            {
                id = a.Id,
                name = a.Name,
                email = a.Email,
                user = a.Username,

                status = a.Status
            });
        }

        public void Delete(int id)
        {
            db.Facilities.Remove(db.Facilities.Find(id));
            db.SaveChanges();
        }

        public dynamic find(int id)
        {
            try
            {
                IQueryable<Facility> a = db.Facilities.Where(x => x.Id == id);
                if (a.Sum(x=> x.Id) == 0)
                    return null;

                return a.Select(x => new
                {
                    id = x.Id,
                    name = x.Name,
                    description = x.Description,
                    head = new { id = x.HeadAccount.Id, name = x.HeadAccount.Name }
                });

            }
            catch
            {
                return null;
            }
        }

        public dynamic update(Facility fa)
        {
            try
            {
                IQueryable<Facility> a = db.Facilities.Where(x => x.Id == fa.Id);
                if (a.Sum(x => x.Id) == 0)
                    return false;

                db.Entry(fa).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
