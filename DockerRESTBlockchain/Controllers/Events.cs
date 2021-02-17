using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DockerRESTBlockchain.Controllers
{
    public class Events : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
