using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebAppClient.Models.ViewModel;

namespace WebAppClient.Controllers.Auth
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return View("Login");
        }
        public IActionResult Login()
        {
            return View();
        }
        // the login opearation
        [Route("Login")]
        [HttpPost]
        public IActionResult Login(Login input)
        {
            string token = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44385/api/");
                var postTask = client.PostAsJsonAsync<Login>("Auth/Login", input);
                postTask.Wait();
                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var resultJsonString = result.Content.ReadAsStringAsync();
                    resultJsonString.Wait();
                    JObject rss = JObject.Parse(resultJsonString.Result);
                    JValue tokenObject = (JValue)rss["token"];
                    token = tokenObject.ToString();
                    HttpContext.Session.SetString("token", token);
                    //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token); // adding token into authorization header
                    //return (RedirectToAction("Index", new { token  }));
                    return View("Success");
                }
            }
            return View("Login");
        }

        [Route("Logout")]
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("token");
            return RedirectToAction("Index");
        }
    }


}
