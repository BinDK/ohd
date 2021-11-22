using Project3.Controllers;
using Project3.Request;
using System;
using System.Collections.Generic;

#nullable disable

namespace Project3.Models
{
    public partial class RequestByUser
    {
        public RequestByUser()
        {
            HeadTasks = new HashSet<HeadTask>();
            ReqLogs = new HashSet<ReqLog>();
            UserTasks = new HashSet<UserTask>();
        }

        public int Id { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? RequestPriorityId { get; set; }
        public int? RequestStatusId { get; set; }
        public string Description { get; set; }
        public int? FacilityId { get; set; }
        public int? AccountId { get; set; }
        public int? ServiceId { get; set; }
        public string ReasonCloseRequest { get; set; }

        public virtual Account Account { get; set; }
        public virtual Facility Facility { get; set; }
        public virtual RequestPriority RequestPriority { get; set; }
        public virtual RequestStatus RequestStatus { get; set; }
        public virtual Service Service { get; set; }
        public virtual ICollection<HeadTask> HeadTasks { get; set; }
        public virtual ICollection<ReqLog> ReqLogs { get; set; }
        public virtual ICollection<UserTask> UserTasks { get; set; }

        internal void addRequestNew(createRequestByUserReq req)
        {
            this.StartDate = DateTime.Now;
            this.EndDate = null;
            this.RequestPriorityId = req.Request_priority_id;
            this.RequestStatusId = req.Request_status_id;
            this.Description = req.Content;
            this.ServiceId = req.Service_id;
            this.AccountId = req.Account_id;
            this.FacilityId = req.Facility.Id;
            this.ReasonCloseRequest = null;
        }
        internal void updateRequestByUser(FinishRequest finishRequest)
        {
            this.RequestStatusId = 3;
            this.EndDate = DateTime.Today;
        }

        //abc
    }
}
