using System;
using System.Collections.Generic;

#nullable disable

namespace Project3.Models
{
    public partial class Facility
    {
        public Facility()
        {
            RequestByUsers = new HashSet<RequestByUser>();
            Services = new HashSet<Service>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? HeadAccountId { get; set; }
        public string Description { get; set; }

        public virtual Account HeadAccount { get; set; }
        public virtual ICollection<RequestByUser> RequestByUsers { get; set; }
        public virtual ICollection<Service> Services { get; set; }
    }
}
