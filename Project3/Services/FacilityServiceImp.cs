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

            return db.Facilities.Select(p => new
            {
                id = p.Id,
                name = p.Name,
                headAccountId = p.HeadAccount,
                description = p.Description,
                headAccount = p.HeadAccount
            }).ToList();
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
    }
}
