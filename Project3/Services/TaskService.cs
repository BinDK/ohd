using Project3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project3.Services
{
   public interface TaskService
    {
        public dynamic FindAllTask();
        public dynamic Finds(int id);

        public UserTask FindTaskById(string id);

        public dynamic UpdateTask1(UserTask userTask);

        public dynamic UpdateTask2(UserTask userTask);

        public dynamic UpdateImplementor(UserTask userTask);

    }
}
