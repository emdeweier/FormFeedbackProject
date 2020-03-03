using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FormFeedback.Models;
using System.Net.Http;
using Microsoft.AspNetCore.Http;
using FormFeedbackAPI.ViewModels;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace FormFeedback.Controllers
{
    public class HomeController : Controller
    {
        readonly HttpClient httpClient = new HttpClient();

        public HomeController()
        {
            httpClient.BaseAddress = new Uri("http://192.168.128.233:1708/");
            //httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJleHAiOjE1ODUyNzQwNDEsImlzcyI6ImJvb3RjYW1wcmVzb3VyY2VtYW5hZ2VtZW50IiwiYXVkIjoicmVhZGVycyJ9.YA-M_KN25FWmUuIS1bd9F5ioiRkVY8NCas1Bjma8kjQ");
        }

        public IActionResult Index()
        {
            var token = HttpContext.Session.GetString("Token");
            if (token == null)
            {
                return View();
            }
            return RedirectToAction("", "Questions");
        }

        [Route("LockedAccount")]
        public IActionResult LockedAccount()
        {
            //var token = HttpContext.Session.GetString("Token");
            //if (token == null)
            //{
            //    return Redirect("/");
            //}
            return View();
        }

        [Route("ForgotPassword")]
        public IActionResult ForgotPassword()
        {
            //var token = HttpContext.Session.GetString("Token");
            //if (token == null)
            //{
            //    return Redirect("/");
            //}
            return View();
        }

        [Route("Logout")]
        public async Task<ActionResult> Logout()
        {
            var token = HttpContext.Session.GetString("Token");
            if (token == null)
            {
                return RedirectToAction("", "Home");
            }
            HttpContext.Session.Remove("Token");
            HttpContext.Session.Remove("Username");
            return RedirectToAction("", "Home");
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public async Task<ActionResult> Login(UserVM userVM)
        {
            var myContent = JsonConvert.SerializeObject(userVM);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var affectedRow = httpClient.PostAsync("Login", byteContent).Result;
            if (affectedRow.IsSuccessStatusCode)
            {
                var readTask = affectedRow.Content.ReadAsStringAsync().Result.Replace("\"", "").Split("...");
                var token = "Bearer " + readTask[0];
                var username = readTask[1];
                var iduser = readTask[2];
                HttpContext.Session.SetString("Token", token);
                var cek = httpClient.GetAsync("Get/" + iduser).Result;
                var read = cek.Content.ReadAsStringAsync().Result;
                userVM.Id = iduser;
                HttpContext.Session.SetString("Username", userVM.Id);
                return Json(new { data = read, affectedRow.StatusCode });
            }
            userVM.Count += 1;
            return Json(new { userVM.Count, affectedRow.StatusCode });
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
