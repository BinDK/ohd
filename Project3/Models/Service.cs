using System;
using System.Collections.Generic;

#nullable disable

namespace Project3.Models
{
    public partial class Service
    {
        public Service()
        {
            RequestByUsers = new HashSet<RequestByUser>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? FacilityId { get; set; }
        public string Description { get; set; }

        public virtual Facility Facility { get; set; }
        public virtual ICollection<RequestByUser> RequestByUsers { get; set; }
    }
}
