using System.Linq;
using System.Threading.Tasks;
using FormFeedbackAPI.Bases;
using FormFeedbackAPI.Models;
using FormFeedbackAPI.Repositories.Data;
using Microsoft.AspNetCore.Mvc;

namespace FormFeedbackAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PointsController : BasesController<Point, PointRepository>
    {
        private readonly PointRepository _repository;

        public PointsController(PointRepository pointRepository) : base(pointRepository)
        {
            _repository = pointRepository;
        }

        [HttpPost]
        [Route("Post")]
        public async Task<IActionResult> Post(Point point)
        {
            var get = await _repository.Get();
            get = get.Where(a => a.Value.Equals(point.Value) || a.Note.Equals(point.Note));
            if (get.Count() > 0)
            {
                return BadRequest();
            }
            else
            {
                point.Create();
                var create = await _repository.Post(point);
                if (create > 0)
                {
                    return Ok(point);
                }
                return BadRequest();
            }
        }
    }
}