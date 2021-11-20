using Project3.Controllers;
using Project3.Models;
using Project3.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project3.Services
{
    public interface MyRequestService
    {
        dynamic FindAll();
        dynamic find(int id);
        dynamic close(CloseRequest req);
        object  Create(createRequestByUserReq req);
        dynamic FindAllAssign(int id);
        dynamic FindHeadTask(int id);
        dynamic updateMyAssignment(UpdateMyAssignmentRequest req);
        object FindReqLog(int id);
    }
}
