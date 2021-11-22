using Project3.Models;
using Project3.Request;
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

                description = f.Note,
                startDate = f.StartDate
            });
        }

        public dynamic FindAllTask(int id)
        {
            return db.UserTasks.Where(a => a.UserAccountId == id).Select(f => new
            {
                status = f.UserTaskStatus,
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

        public dynamic UpdateTask2(FinishRequest finishRequest)
        {
            try
            {
                IQueryable<RequestByUser> a = db.RequestByUsers.Where(x => x.Id == finishRequest.request_by_user_id);
                if (a.Sum(x => x.Id) == 0)
                    return false;

                RequestByUser requestByUser = a.FirstOrDefault();
                // finish user_task
                requestByUser.updateRequestByUser(finishRequest);

                db.Entry(requestByUser).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
                // update user task
                this.UpdateUserTask(finishRequest);

                // add log
               /* this.addLog(finishRequest);*/
                return true;
            }
            catch
            {
                return null;
            }
        }

        public dynamic UpdateUserTask(FinishRequest finishRequest)
        {
            try
            {
                IQueryable<UserTask> a = db.UserTasks.Where(x => x.RequestByUserId == finishRequest.request_by_user_id);
                if (a.Sum(x => x.RequestByUserId) == 0)
                    return false;

                db.Entry(finishRequest).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return null;
            }
        }

        public void addLog(FinishRequest finishRequest, UserTask userTask)
        {
            try
            {
                ReqLog reqLog = new ReqLog
                {
                    UserAccountId = userTask.UserAccountId,
                    LogTime = DateTime.Now,
                    ReqContent = "Request’s has been finished",
                    RequestByUserId = userTask.RequestByUserId,
                    Status = "Finnished"
                };
                db.Entry(userTask).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();

            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
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
