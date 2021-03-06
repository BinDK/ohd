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

            return db.Facilities.Select(f => new
            {
                id = f.Id,
                name = f.Name,
                headAccountId = f.HeadAccountId,
                head = new
                {
                    id = f.HeadAccount.Id,
                    name = f.HeadAccount.Name
                },
                description = f.Description

            }).ToList();
        }

        public dynamic CreateFacility(Facility facility)
        {
            if (NameCheck(facility.Name))
            {
                return null;
            }
            else
            {
                db.Facilities.Add(facility);
                db.SaveChanges();
                return facility;
            }
        }

        public bool NameCheck(string name)
        {
            return db.Facilities.Count(f => f.Name == name) > 0;
        }

     
        public void Delete(int id)
        {
            db.Facilities.Remove(db.Facilities.Find(id));
            db.SaveChanges();
        }

        public dynamic Finds(int id)
        {
            try
            {
                IQueryable<Facility> a = db.Facilities.Where(x => x.Id == id);
                if (a.Sum(x => x.Id) == 0)
                    return null;

                return a.Select(x => new
                {
                    id = x.Id,
                    name = x.Name,
                    headAccountId = x.HeadAccountId,
                    head = new
                    {
                        id = x.HeadAccount.Id,
                        name = x.HeadAccount.Name
                    },
                    description = x.Description
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

        public dynamic FindAllByHead(int id)
        {
            return db.Facilities.Where(a => a.HeadAccountId == id).Select(f => new
            {
                id = f.Id,
                name = f.Name,
                headAccountId = f.HeadAccountId,
                head = new
                {
                    id = f.HeadAccount.Id,
                    name = f.HeadAccount.Name
                },
                description = f.Description

            }).ToList();
        }
        public dynamic FindAllByName(string name)
        {
            return db.Facilities.Where(a => a.Name == name).Select(f => new
            {
                id = f.Id,
                name = f.Name,
                headAccountId = f.HeadAccountId,
                head = new
                {
                    id = f.HeadAccount.Id,
                    name = f.HeadAccount.Name
                },
                description = f.Description

            }).ToList(); 
        }
    }
}
