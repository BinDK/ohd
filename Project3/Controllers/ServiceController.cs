using Microsoft.AspNetCore.Mvc;
using Project3.Models;
using Project3.Services;
using System;
using System.Diagnostics;

namespace Project3.Controllers
{
    [Route("api/service")]
    public class ServiceController : Controller
    {
        private ServiceService serviceService;

        public ServiceController(ServiceService serviceService)
        {
            this.serviceService = serviceService;
        }

       
    }
}
