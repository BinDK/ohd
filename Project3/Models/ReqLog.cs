using System;
using System.Collections.Generic;

#nullable disable

namespace Project3.Models
{
    public partial class ReqLog
    {
        public int Id { get; set; }
        public int? RequestByUserId { get; set; }
        public DateTime? LogTime { get; set; }
        public string Status { get; set; }
        public string ReqContent { get; set; }
        public int? UserAccountId { get; set; }

        public virtual RequestByUser RequestByUser { get; set; }
        public virtual Account UserAccount { get; set; }
    }
}
