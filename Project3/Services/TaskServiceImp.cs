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
                startDate = f.StartDate,
                headtask = f.HeadTask
            });
        }

        public dynamic FindAllTask(int id)
        {
            return db.UserTasks.Where(a => a.UserAccountId == id).Select(f => new
            {
                status = f.UserTaskStatus,
                description = f.Note,
                startDate = f.StartDate,
                headtask = f.HeadTask

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
                IQueryable<RequestByUser> a = db.RequestByUsers.Where(x => x.Id == finishRequest.Id);
                if (a.Sum(x => x.Id) == 0)
                    return false;
                RequestByUser requestByUser = a.FirstOrDefault();

                requestByUser.EndDate = DateTime.Now;
                requestByUser.RequestStatusId = finishRequest.request_status_id;

                Debug.WriteLine(requestByUser + "------------gán ở chỗ này------------------------");
                db.Entry(requestByUser).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();

                Debug.WriteLine(requestByUser + "------------Update xong RequestByUser------------------------");
                // update userTask
                IQueryable<UserTask> b = db.UserTasks.Where(x => x.RequestByUserId == finishRequest.Id);
                if (b.Sum(x => x.RequestByUserId) == 0)
                    return false;
                UserTask userTask = b.FirstOrDefault();

                userTask.UserTaskStatus = "Finished";
                userTask.EndDate = DateTime.Now;
                userTask.Note = finishRequest.Note;
                db.Entry(userTask).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                Debug.WriteLine(requestByUser + "------------Update xong UserTask------------------------");
                // create log

                ReqLog reqLog = new ReqLog
                {
                    UserAccountId = userTask.UserAccountId ,
                    LogTime = DateTime.Now,
                    ReqContent = "Request’s has been finished",
                    RequestByUserId = finishRequest.Id,
                    Status = "Assigned"
                };
                this.db.ReqLogs.Add(reqLog);
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

        public dynamic UpdateImplementor(ChangeImplementor changeImplementor)
        {
            try
            {
                IQueryable<UserTask> a = db.UserTasks.Where(x => x.RequestByUserId == changeImplementor.Id);
                if (a.Sum(x => x.RequestByUserId) == 0)
                    return false;

                UserTask userTask = a.FirstOrDefault();
                userTask.UserAccountId = changeImplementor.Assignee_id;

                db.Entry(userTask).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                ReqLog reqLog = new ReqLog
                {
                    UserAccountId = userTask.UserAccountId,
                    LogTime = DateTime.Now,
                    ReqContent = "Request’s has been been re-assigned ",
                    RequestByUserId = changeImplementor.Id,
                    Status = "Assigned"
                };
                this.db.ReqLogs.Add(reqLog);

                db.SaveChanges();

                return true;
            }
            catch
            {
                return null;
            }
        }

        //abc
    }
}
