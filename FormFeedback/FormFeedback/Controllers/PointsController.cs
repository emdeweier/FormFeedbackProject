using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using FormFeedbackAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FormFeedback.Controllers
{
    public class PointsController : Controller
    {
        readonly HttpClient httpClient = new HttpClient();

        public PointsController()
        {
            httpClient.BaseAddress = new Uri("https://localhost:44370/api/");
            httpClient.DefaultRequestHeaders.Accept.Clear();
        }

        // GET: Points
        public ActionResult Index()
        {
            ViewBag.Points = Points();
            return View();
        }

        // GET: Points List
        public IList<Point> Points()
        {
            IList<Point> points = null;
            var responseTask = httpClient.GetAsync("Points");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<Point>>();
                readTask.Wait();
                points = readTask.Result;
            }

            return points;
        }

        // GET: Points/Create
        public async Task<ActionResult> Create(Point point)
        {
            //httpClient.DefaultRequestHeaders.Add("Authorization", HttpContext.Session.GetString("Token"));
            var myContent = JsonConvert.SerializeObject(point);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var affectedRow = httpClient.PostAsync("Points/Post", byteContent).Result;
            return Json(new { data = affectedRow, affectedRow.StatusCode });
        }

        public JsonResult Get(int id)
        {
            //httpClient.DefaultRequestHeaders.Add("Authorization", HttpContext.Session.GetString("Token"));
            var cek = httpClient.GetAsync("Points/" + id).Result;
            var read = cek.Content.ReadAsAsync<Point>().Result;
            return Json(new { data = read });
        }

        // POST: Points/Edit/
        public ActionResult Edit(int Id, Point point)
        {
            var myContent = JsonConvert.SerializeObject(point);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var ByteContent = new ByteArrayContent(buffer);
            ByteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var update = httpClient.PutAsync("Points/" + Id, ByteContent).Result;
            return Json(new { data = update, update.StatusCode });
        }

        // GET: Points/Delete/
        public JsonResult Delete(int id)
        {
            var affectedRow = httpClient.DeleteAsync("Points/Delete/" + id).Result;
            return Json(new { data = affectedRow });
        }
    }
}