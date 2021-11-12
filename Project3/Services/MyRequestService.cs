using Project3.Controllers;
using Project3.Models;
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
        object Create(createRequestByUserReq req);
        dynamic FindAllAssign();
    }
}
