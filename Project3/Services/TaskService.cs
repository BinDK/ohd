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
        public dynamic Find(int id);

        public dynamic UpdateTask(UserTask userTask);


    }
}
