using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebAppClient.Models;

namespace WebAppClient.Controllers
{
    //[Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        IHttpContextAccessor HttpContextAccessor = new HttpContextAccessor();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            if(HttpContextAccessor.HttpContext.Session.GetString("token") != null)
            {
                return View();
            }
            return RedirectToAction("Index", "Auth"); 
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult NotFound404()
        {
            return View("NotFound");
        }

        public IActionResult Forbidden()
        {
            return View("Forbidden");
        }
        public IActionResult Unauth()
        {
            return View("Unauthorized");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
