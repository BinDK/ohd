using Microsoft.Extensions.Configuration;
using Project3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project3.Services
{
    public class AdminServiceImp : AdminService
    {


        private DatabaseContext db;

        public AdminServiceImp(DatabaseContext db)
        {
            this.db = db;
        }

        public dynamic listAccount()
        {
            return db.Accounts.Select(x => new
            {
                id = x.Id,
                name = x.Name,
                email = x.Email,
                username = x.Username,
                roleId = x.RoleId,
                role = new { id = x.RoleId, name = x.Role.Name },
                status = x.Status

            }).ToList();
        }


        public dynamic listRole()
        {
            return db.Roles.ToList().Select(x => new
            {
                id = x.Id,
                name = x.Name
            });
        }

        public dynamic addAccount(Account account)
        {
            if (Check(account.Username, account.Email))
            {
                return null;
            }
            else
            {
                db.Accounts.Add(account);
                db.SaveChanges();
                return account;
            }

        }


        public dynamic Check(string username, string email)
        {
            return (db.Accounts.Count(i => i.Username == username && i.Email == email)) > 0;
        }

        public dynamic FindAllHead()
        {
            return db.Accounts.Where(p => p.RoleId == 2).Select(f => new
            {
                id = f.Id,
                name = f.Name,
            }).ToList();
        }

        public dynamic findAccount(int id)
        {
            try
            {
                IQueryable<Account> a = db.Accounts.Where(x => x.Id == id);
                if (a.Sum(a => a.Id) == 0)
                    return null;

                return a.Select(x => new
                {
                    id = x.Id,
                    name = x.Name,
                    email = x.Email,
                    username = x.Username,
                    role = new { id = x.Role.Id, name = x.Role.Name },
                    status = x.Status
                });

            }
            catch
            {
                return null;
            }
        }

        public dynamic Finds(int id)
        {
            return db.Accounts.Select(a => new
            {
                id = a.Id,
                name = a.Name,
                email = a.Email,
                user = a.Username,
                roleId = a.RoleId,
                status = a.Status
            }).SingleOrDefault(a => a.id == id);
        }

        public void deleteAccount(int id)
        {
            db.Accounts.Remove(db.Accounts.Find(id));
            db.SaveChanges();
        }

        public dynamic updateAccount(Account ac)
        {
            try
            {
                IQueryable<Account> a = db.Accounts.Where(x => x.Id == ac.Id);
                if (a.Sum(a => a.Id) == 0)
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