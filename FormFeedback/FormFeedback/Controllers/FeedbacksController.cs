using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using FormFeedbackAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FormFeedback.Controllers
{
    public class FeedbacksController : Controller
        
    {
        readonly HttpClient httpClient = new HttpClient();

        public FeedbacksController()
        {
            httpClient.BaseAddress = new Uri("https://localhost:44370/api/");
            httpClient.DefaultRequestHeaders.Accept.Clear();
        }

        public ActionResult Index()
        {
            return View();
        }
        // Get: Feedbacks/Details/5
        public IList<FeedbackVM> Feedbacks()
        {
            IList<FeedbackVM> feedbacks = null;
            var responseTask = httpClient.GetAsync("Feedbacks");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<FeedbackVM>>();
                readTask.Wait();
                feedbacks = readTask.Result;
            }
            return feedbacks;
        }
    }
}