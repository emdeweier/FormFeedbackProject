using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using FormFeedbackAPI.Models;
using FormFeedbackAPI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FormFeedback.Controllers
{
    public class QuestionsController : Controller
    {
        readonly HttpClient httpClient = new HttpClient();

        public QuestionsController()
        {
            httpClient.BaseAddress = new Uri("https://localhost:44370/api/");
            httpClient.DefaultRequestHeaders.Accept.Clear();
        }

        // GET: Questions
        public ActionResult Index()
        {
            ViewBag.Questions = Questions();
            ViewBag.Options = Options();
            return View();
        }

        // GET: Questions/Details/5
        public IList<QuestionVM> Questions()
        {
            IList<QuestionVM> questions = null;
            var responseTask = httpClient.GetAsync("Questions");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<QuestionVM>>();
                readTask.Wait();
                questions = readTask.Result;
            }

            return questions;
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

        // GET: Questions/Create
        public async Task<ActionResult> Create(QuestionVM questionVM)
        {
            var myContent = JsonConvert.SerializeObject(questionVM);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var affectedRow = httpClient.PostAsync("Questions", byteContent).Result;
            return Json(new { data = affectedRow });
        }

        public JsonResult Get(string id)
        {
            var cek = httpClient.GetAsync("Questions/" + id).Result;
            var read = cek.Content.ReadAsAsync<QuestionVM>().Result;
            return Json(new { data = read });
        }

        // POST: Questions/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: Questions/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Questions/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}