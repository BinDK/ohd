using System;
using System.Collections.Generic;

#nullable disable

namespace Project3.Models
{
    public partial class Account
    {
        public Account()
        {
            Facilities = new HashSet<Facility>();
            HeadTasks = new HashSet<HeadTask>();
            ReqLogs = new HashSet<ReqLog>();
            RequestByUsers = new HashSet<RequestByUser>();
            UserTasks = new HashSet<UserTask>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int? RoleId { get; set; }
        public bool? Status { get; set; }

        public virtual Role Role { get; set; }
        public virtual ICollection<Facility> Facilities { get; set; }
        public virtual ICollection<HeadTask> HeadTasks { get; set; }
        public virtual ICollection<ReqLog> ReqLogs { get; set; }
        public virtual ICollection<RequestByUser> RequestByUsers { get; set; }
        public virtual ICollection<UserTask> UserTasks { get; set; }
    }
}
