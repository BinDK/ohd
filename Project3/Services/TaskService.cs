using Project3.Models;
using Project3.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project3.Services
{
   public interface TaskService
    {
        public dynamic FindAllTask(int id);
        public dynamic Finds(int id);

        public UserTask FindTaskById(string id);

        public dynamic UpdateTask1(UserTask userTask);

        public dynamic UpdateTask2(FinishRequest finishRequest);

        public dynamic UpdateImplementor(ChangeImplementor changeImplementor);
        //abc
    }
}
