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
        public virtual ICollection<UserTask> UserTasks { get; set; }
    }
}
