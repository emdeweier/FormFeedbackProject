using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using FormFeedbackAPI.Models;
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

        // GET: Options List
        //public JsonResult LoadOptions(int param)
        //{
        //    IList<Option> options = null;
        //    var responseTask = httpClient.GetAsync("Options");
        //    responseTask.Wait();
        //    var result = responseTask.Result;
        //    if (result.IsSuccessStatusCode)
        //    {
        //        var readTask = result.Content.ReadAsAsync<IList<Option>>();
        //        readTask.Wait();
        //        options = readTask.Result;
        //    }
        //    jsonOptions = JsonConvert.SerializeObject(options, Formatting.Indented);
        //    return Json(jsonOptions);
        //}

        // POST: Options/Create
        public async Task<ActionResult> Create(Option option)
        {
            var myContent = JsonConvert.SerializeObject(option);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var affectedRow = httpClient.PostAsync("Options/Post", byteContent).Result;
            return Json(new { data = affectedRow, affectedRow.StatusCode });
        }

        public JsonResult Get(string id)
        {
            var cek = httpClient.GetAsync("Options/" + id).Result;
            var read = cek.Content.ReadAsAsync<Option>().Result;
            return Json(new { data = read });
        }

        // POST: Options/Edit/
        public ActionResult Edit(string id, Option option)
        {
            var myContent = JsonConvert.SerializeObject(option);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var ByteContent = new ByteArrayContent(buffer);
            ByteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var update = httpClient.PutAsync("Options/" + id, ByteContent).Result;
            return Json(new { data = update, update.StatusCode });
        }

        // GET: Options/Delete/
        public JsonResult Delete(string id)
        {
            var affectedRow = httpClient.DeleteAsync("Options/Delete/" + id).Result;
            return Json(new { data = affectedRow });
        }
    }
}