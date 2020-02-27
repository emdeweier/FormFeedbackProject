using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FormFeedbackAPI.Models;
using FormFeedbackAPI.Services.Interfaces;
using FormFeedbackAPI.ViewModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FormFeedbackAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        IQuestionService _questionService;

        public QuestionsController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IEnumerable<QuestionVM> GetQuestions()
        {
            return _questionService.Get();
        }

        [HttpGet("{Id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult GetQuestions(string id)
        {
            var questions = _questionService.Get(id);
            return Ok(questions);
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult PostQuestions(QuestionVM questionVM)
        {
            var post = _questionService.Add(questionVM);
            if (post > 0)
            {
                return Ok(post);
            }
            return BadRequest();
        }

        [HttpPut("{Id}")]
        public ActionResult PutQuestions(string id, QuestionVM questionVM)
        {
            var put = _questionService.Edit(id, questionVM);
            if (put > 0)
            {
                return Ok(put);
            }
            return BadRequest();
        }

        [HttpDelete]
        public ActionResult Delete(string id)
        {
            var delete = _questionService.Delete(id);
            if (delete)
            {
                return Ok(delete);
            }
            return BadRequest();
        }
    }
}