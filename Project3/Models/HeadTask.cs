using Project3.Controllers;
using System;
using System.Collections.Generic;

#nullable disable

namespace Project3.Models
{
    public partial class HeadTask
    {
        public HeadTask()
        {
            UserTasks = new HashSet<UserTask>();
        }

        public int Id { get; set; }
        public int? RequestByUserId { get; set; }
        public string HeadTaskStatus { get; set; }
        public string Note { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? HeadAccountId { get; set; }

        public virtual Account HeadAccount { get; set; }
        public virtual RequestByUser RequestByUser { get; set; }
        public virtual ICollection<UserTask> UserTasks { get; set; }

        internal void addHeadTasks(createRequestByUserReq req, int id)
        {
            this.RequestByUserId = id;
            this.HeadTaskStatus = "Ongoing";
            this.Note = null;
            this.StartDate = DateTime.Today;
            this.EndDate = null;
            this.HeadAccountId = req.Facility.HeadAccountId;
        }
    }
}
