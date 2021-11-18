using Project3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project3.Services
{
    public class ReqLogServiceImp : ReqLogService
    {
        private DatabaseContext db;

        public ReqLogServiceImp(DatabaseContext db)
        {
            this.db = db;
        }
        public dynamic FindAllReg()
        {
            return db.ReqLogs.Select(f => new
            {
                id = f.Id,
                request_by_user_id = f.RequestByUserId,
                log_time = f.LogTime,
                status = f.Status,
                req_content = f.ReqContent,
                user_account_id = f.UserAccountId
            });
        }
    }
}
