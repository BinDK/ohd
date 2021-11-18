using Project3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project3.Services
{
    public class TaskServiceImp : TaskService
    {
        private DatabaseContext db;

        public TaskServiceImp(DatabaseContext db)
        {
            this.db = db;
        }

        public dynamic Find(int id)
        {
            return db.UserTasks.Where(a => a.Id == id).Select(f => new
            {
                facility = f.UserAccount.Facilities,
                service = f.RequestByUser.Service,
                status = f.UserAccount.Status,
                description = f.Note,
                startDate = f.StartDate
            });
        }
             
        public dynamic FindAllTask()
        {
            return db.UserTasks.Select(f => new
            {
                facility = f.UserAccount.Facilities ,
                service = f.RequestByUser.Service,
                status = f.UserAccount.Status,
                description = f.Note,
                startDate = f.StartDate
                            
            }).ToList();
        }

        public dynamic UpdateTask(UserTask userTask)
        {
            db.Entry(userTask).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return null;
        }
    }
}
