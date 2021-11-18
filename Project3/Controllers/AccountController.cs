using Microsoft.AspNetCore.Mvc;
using Project3.Models;
using Project3.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project3.Controllers
{
    [Route("api/account")]
    public class AccountController : Controller
    {

        private AccountService accountService;

        public AccountController(AccountService _accountService)
        {
            this.accountService = _accountService;
        }


        [Consumes("application/json")]
        [Produces("application/json")]
        [HttpPost("login")]
        public IActionResult Login([FromBody] UsernameAndPassword usernameAndPassword)
        {
            try
            {
                return Ok(new
                {
                    Result = accountService.Login(usernameAndPassword.Username, usernameAndPassword.Password)
                });
            }
            catch
            {
                return BadRequest();
            }
        }

       
    }
}
