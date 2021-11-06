using Project3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project3.Services
{
    public class PriorityServiceImp : PriorityService
    {
        private DatabaseContext db;
        public PriorityServiceImp(DatabaseContext db)
        {
            this.db = db;
        }
        public dynamic CreatePriority(RequestPriority requestPriority)
        {
            db.RequestPriorities.Add(requestPriority);
            db.SaveChanges();
            return requestPriority;
        }

        public void deletePriority(int id)
        {
            db.RequestPriorities.Remove(db.RequestPriorities.Find(id));
            db.SaveChanges();
        }

        public dynamic FindAll()
        {
            return db.RequestPriorities.Select(a => new
            {
                id = a.Id,
                name = a.Name,
                status = a.Status
            }).ToList();
        }

        public dynamic Finds(int id)
        {
            try
            {
                IQueryable<RequestPriority> a = db.RequestPriorities.Where(x => x.Id == id);
                if (a.Sum(a => a.Id) == 0)
                    return null;

                return a.Select(x => new
                {
                    id = x.Id,
                    name = x.Name,
                    status = x.Status
                });

            }
            catch
            {
                return null;
            }
        }

        public dynamic updatePriority(RequestPriority requestPriority)
        {
            try
            {
                IQueryable<RequestPriority> a = db.RequestPriorities.Where(x => x.Id == requestPriority.Id);
                if (a.Sum(a => a.Id) == 0)
                    return false;
                db.Entry(requestPriority).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
