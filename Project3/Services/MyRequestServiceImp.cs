using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Configuration;
using Project3.Controllers;
using Project3.Models;
using Project3.Request;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Project3.Services
{
    public class MyRequestServiceImp : MyRequestService
    {

        private IConfiguration conf;

      
        private DatabaseContext db;

        public MyRequestServiceImp(DatabaseContext db, IConfiguration _conf)
        {
            this.db = db;
            this.conf = _conf;
        }
    

        public dynamic find(int id)
        {
            try
            {
                IQueryable<RequestByUser> a = db.RequestByUsers.Where(x => x.Id == id);
                if (a.Sum(a => a.Id) == 0)
                    return null;

                return a.Select(x => new
                {
                    Id = x.Id,
                    AccountId = x.AccountId,
                    Description = x.Description,
                    EndDate = x.EndDate,
                    Facility = new { id = x.Facility.Id, name = x.Facility.Name },
                    Service = new { id = x.Service.Id, name = x.Service.Name },
                    StartDate = x.StartDate,
                    RequestStatus = new { id = x.RequestStatus.Id, name = x.RequestStatus.Name },
                    ReasonCloseRequest = x.ReasonCloseRequest,
                    RequestPriority = new { id = x.RequestPriority.Id, name = x.RequestPriority.Name }
                });

            }
            catch
            {
                return null;
            }
        }

  
        public dynamic FindAll()
        {
            return db.RequestByUsers.Select(x => new
            {
                Id = x.Id,
                AccountId = x.AccountId,
                Description = x.Description,
                EndDate = x.EndDate,
                Facility = new { id = x.Facility.Id, name = x.Facility.Name},
                Service = new { id = x.Service.Id, name = x.Service.Name },
                StartDate = x.StartDate,
                RequestStatus = new { id = x.RequestStatus.Id, name = x.RequestStatus.Name },
                ReasonCloseRequest = x.ReasonCloseRequest,
                RequestPriority= new { id = x.RequestPriority.Id, name = x.RequestPriority.Name }
              


            }).ToList();
        }

        public dynamic close(CloseRequest req)
        {
            try
            {
                IQueryable<RequestByUser> a = db.RequestByUsers.Where(x => x.Id == req.Request_by_user_id);
                if (a.Sum(a => a.Id) == 0)
                    return false;
                RequestByUser ac = db.RequestByUsers.Find(req.Request_by_user_id);
                this.updateReasonCloseRequestByUsers(ac, req.Reason);
                db.Entry(ac).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return null;
            }
        }

        private void updateReasonCloseRequestByUsers(RequestByUser ac, string reason)
        {
            ac.ReasonCloseRequest = reason;
        }

        public dynamic Create(createRequestByUserReq req)
        {
            try
            {
                RequestByUser requestByUser = 
                this.addRequestByUser(req);
                this.addHeadTasks(req,requestByUser);
                /*
                 * Send Email for user create request 
                 */
                this.sendEmailToUser(req);
                /*
                 * Send Email for head of facility 
                 * */
                this.sendEmailToHead(req);
                /*
                 * Save log when create request
                */
                this.addLogForReqLog(req, requestByUser);

                return true;

            }
            catch
            {
                return null;
            }
        }

        private void addLogForReqLog(createRequestByUserReq req, RequestByUser requestByUser)
        {
            ReqLog reqLog = new ReqLog
            {
                UserAccountId = req.Account_id,
                LogTime = DateTime.Now,
                ReqContent = "Request’s created",
                RequestByUserId = requestByUser.Id,
                Status = "Created"

            };
            this.db.ReqLogs.Add(reqLog);
            this.db.SaveChanges();
        }

        private void sendEmailToHead(createRequestByUserReq req)
        {
            Account head = db.Accounts.First(x => x.Id == req.Facility.HeadAccountId);
            string subject = conf["gmail:subject"].ToString();
            string body = conf["gmail:userCreateRequest"].ToString();
            Utils.Utils.SendMail(
                conf["gmail:username"].ToString(),
                head.Email,
                subject,
                body,
                conf["gmail:username"].ToString(),
                conf["gmail:password"].ToString()
                );
        }

        private void sendEmailToUser(createRequestByUserReq req)
        {
            Account user = db.Accounts.First(x => x.Id == req.Account_id);
            string subject = conf["gmail:subject"].ToString();
            string body = conf["gmail:userCreateRequest"].ToString();
            Utils.Utils.SendMail(
                conf["gmail:username"].ToString(),
                user.Email,
                subject,
                body,
                conf["gmail:username"].ToString(),
                conf["gmail:password"].ToString()
                );
        }

        private void addHeadTasks(createRequestByUserReq req, RequestByUser requestByUser)
        {
            HeadTask headTask = new HeadTask();
            headTask.addHeadTasks(req, requestByUser.Id);
            db.HeadTasks.Add(headTask);
            db.SaveChanges();
        }

        private RequestByUser addRequestByUser(createRequestByUserReq req)
        {
            RequestByUser requestByUser = new RequestByUser();
            requestByUser.addRequestNew(req);
            EntityEntry <RequestByUser > req1 = db.RequestByUsers.Add(requestByUser);
            db.SaveChanges();
            return req1.Entity;
        }

        public dynamic FindAllAssign()
        {
            return db.HeadTasks.Select(x => new
            {
                Id = x.Id,
                RequestByUserId = x.RequestByUserId,
                HeadTaskStatus = x.HeadTaskStatus,
                Note = x.Note,
                StartDate = x.StartDate,
                EndDate = x.EndDate,
                HeadAccountId = x.HeadAccountId

            }).ToList();
        }


        public dynamic FindHeadTask(int id)
        {
            try
            {
                IQueryable<HeadTask> a = db.HeadTasks.Where(x => x.RequestByUserId == id);
                if (a.Sum(a => a.Id) == 0)
                    return null;

                return a.Select(x => new
                {
                    Id = x.Id,
                    RequestByUserId = x.RequestByUserId,
                    HeadTaskStatus = x.HeadTaskStatus,
                    Note = x.Note,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate,
                    HeadAccount = new
                    {
                        Id = x.HeadAccount.Id,
                        Name = x.HeadAccount.Name
                    }

                });

            }
            catch
            {
                return null;
            }
        }

        public dynamic updateMyAssignment(UpdateMyAssignmentRequest req)
        {
            try
            {
                IQueryable<HeadTask> a = db.HeadTasks.Where(x => x.RequestByUserId == req.request_by_user_id);
                if (a.Sum(a => a.Id) == 0)
                    return false;
                HeadTask headTask = a.FirstOrDefault();
                /*
                 * Finished HeadTask
                 */
                headTask.updateMyAssignment(req);
                db.Entry(headTask).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();

                /*
                 * Create User_task for assignee
                 */

                this.createUserTask(req, headTask);

                /*
                 *  Add log 
                 */
                this.addLogWhenUpdateAssignee(req, headTask);

                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return null;
            }
        }

        private void addLogWhenUpdateAssignee(UpdateMyAssignmentRequest req, HeadTask headTask)
        {
            ReqLog reqLog = new ReqLog
            {
                UserAccountId = headTask.HeadAccountId,
                LogTime = DateTime.Now,
                ReqContent = "Request’s assigned",
                RequestByUserId = req.request_by_user_id,
                Status = "Assigned"
            };
            this.db.ReqLogs.Add(reqLog);
            this.db.SaveChanges();
        }

        private void createUserTask(UpdateMyAssignmentRequest req, HeadTask headTask)
        {
            try
            {
                UserTask userTask = new UserTask
                {
                    RequestByUserId = req.request_by_user_id,
                    UserTaskStatus = "Ongoing",
                    Note = "",
                    StartDate = DateTime.Today,
                    EndDate = null,
                    HeadTaskId = headTask.Id,
                    UserAccountId = req.assignee_id
                };
                db.Entry(userTask).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();

            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }
    }
}