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
    public class OptionsController : Controller
    {
        readonly HttpClient httpClient = new HttpClient();

        public OptionsController()
        {
            httpClient.BaseAddress = new Uri("https://localhost:44370/api/");
            httpClient.DefaultRequestHeaders.Accept.Clear();
        }

        // GET: Options
        public ActionResult Index()
        {
            ViewBag.Options = Options();
            return View();
        }

        // GET: Options List
        public IList<Option> Options()
        {
            IList<Option> options = null;
            var responseTask = httpClient.GetAsync("Options");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<Option>>();
                readTask.Wait();
                options = readTask.Result;
            }

            return options;
        }

        // POST: Options/Create
        public async Task<ActionResult> Create(Option option)
        {
            var myContent = JsonConvert.SerializeObject(option);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var affectedRow = httpClient.PostAsync("Options", byteContent).Result;
            return Json(new { data = affectedRow });
        }

        public JsonResult Get(string id)
        {
            var cek = httpClient.GetAsync("Options/" + id).Result;
            var read = cek.Content.ReadAsAsync<Option>().Result;
            return Json(new { data = read });
        }

        // POST: Options/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, Option option)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Options/Delete/
        public JsonResult Delete(string id)
        {
            var affectedRow = httpClient.DeleteAsync("Options/" + id).Result;
            return Json(new { data = affectedRow });
        }
    }
}