using FormFeedbackAPI.Bases;
using FormFeedbackAPI.Models;
using FormFeedbackAPI.Repositories.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace FormFeedbackAPI.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    //public class QuestionsController : ControllerBase
    //{
    //    IQuestionService _questionService;

    //    public QuestionsController(IQuestionService questionService)
    //    {
    //        _questionService = questionService;
    //    }

    //    [HttpGet]
    //    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    //    public IEnumerable<QuestionVM> GetQuestions()
    //    {
    //        return _questionService.Get();
    //    }

    //    [HttpGet("{Id}")]
    //    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    //    public ActionResult GetQuestions(string id)
    //    {
    //        var questions = _questionService.Get(id);
    //        return Ok(questions);
    //    }

    //    [HttpPost]
    //    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    //    public ActionResult PostQuestions(QuestionVM questionVM)
    //    {
    //        var post = _questionService.Add(questionVM);
    //        if (post > 0)
    //        {
    //            return Ok(post);
    //        }
    //        return BadRequest();
    //    }

    //    [HttpPut("{Id}")]
    //    public ActionResult PutQuestions(string id, QuestionVM questionVM)
    //    {
    //        var put = _questionService.Edit(id, questionVM);
    //        if (put > 0)
    //        {
    //            return Ok(put);
    //        }
    //        return BadRequest();
    //    }

    //    [HttpDelete("{Id}")]
    //    public ActionResult Delete(string id)
    //    {
    //        var delete = _questionService.Delete(id);
    //        if (delete)
    //        {
    //            return Ok(delete);
    //        }
    //        return BadRequest();
    //    }
    //}

    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : BasesController<Question, QuestionRepository>
    {
        private readonly QuestionRepository _repository;

        public QuestionsController(QuestionRepository questionRepository) : base(questionRepository)
        {
            _repository = questionRepository;
        }

        [HttpPost]
        [Route("Post")]
        public async Task<IActionResult> Post(Question question)
        {
            var get = await _repository.Get();
            get = get.Where(a => a.Q_Name.Equals(question.Q_Name) & a.Type.Equals(question.Type) & a.OptionId.Equals(question.OptionId));
            if(get.Count() > 0)
            {
                return BadRequest();
            }
            else
            {
                question.Create();
                var create = await _repository.Post(question);
                if (create > 0)
                {
                    return Ok(question);
                }
                return BadRequest();
            }
        }
    }
}