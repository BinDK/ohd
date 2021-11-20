using Project3.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
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

        public dynamic Finds(int id)
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
                facility = f.UserAccount.Facilities,
                service = f.RequestByUser.Service,
                status = f.UserAccount.Status,
                description = f.Note,
                startDate = f.StartDate

            }).ToList();
        }

        public dynamic UpdateTask1(UserTask userTask)
        {

            /*  dynamic s = DateTime.Now.ToString("yyyyMMdd");
              Debug.WriteLine(s+"------------------------------");
              s = Convert.ToDateTime(s);
              userTask.EndDate = s;*/
            // userTask.EndDate = DateTime.Now;
            /*   Debug.WriteLine(userTask.EndDate);*/


            /* var s = DateTime.Now;
             s = s.ToString("yyyy-MM-dd");
             userTask.EndDate = s;*/

            /*    userTask.EndDate = DateTime.Now;

                userTask.UserTaskStatus = "Finished";*/
            db.Entry(userTask).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return userTask;
        }

        public dynamic UpdateTask2(UserTask userTask)
        {
            try
            {
                IQueryable<UserTask> a = db.UserTasks.Where(x => x.Id == userTask.Id);
                if (a.Sum(x => x.Id) == 0)
                    return false;
      /*          userTask.EndDate = DateTime.Now;
                userTask.UserTaskStatus = "Finished";*/
                db.Entry(userTask).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return null;
            }
        }

        public UserTask FindTaskById(string id)
        {
            return db.UserTasks.Find(id);
        }

        public dynamic UpdateImplementor(UserTask userTask)
        {
            try
            {
                IQueryable<UserTask> a = db.UserTasks.Where(x => x.Id == userTask.Id);
                if (a.Sum(x => x.Id) == 0)
                    return false;
                
                db.Entry(userTask).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
