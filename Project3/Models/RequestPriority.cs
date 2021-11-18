using System;
using System.Collections.Generic;

#nullable disable

namespace Project3.Models
{
    public partial class RequestPriority
    {
        public RequestPriority()
        {
            RequestByUsers = new HashSet<RequestByUser>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public bool? Status { get; set; }
        public virtual ICollection<RequestByUser> RequestByUsers { get; set; }
    }
}
