using System;
using System.Collections.Generic;

#nullable disable

namespace Project3.Models
{
    public partial class UserTask
    {
        public int Id { get; set; }
        public int? RequestByUserId { get; set; }
        public string UserTaskStatus { get; set; }
        public string Note { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? HeadTaskId { get; set; }
        public int? UserAccountId { get; set; }

        public virtual HeadTask HeadTask { get; set; }
        public virtual RequestByUser RequestByUser { get; set; }
        public virtual Account UserAccount { get; set; }
    }
}
