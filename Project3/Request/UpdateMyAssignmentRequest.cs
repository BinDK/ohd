using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project3.Request
{
    public class UpdateMyAssignmentRequest
    {
        public int request_by_user_id { get; set; }
        public int assignee_id { get; set; }
        public string note { get; set; }

    }
}
