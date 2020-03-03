using System.Linq;
using System.Threading.Tasks;
using FormFeedbackAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FormFeedbackAPI.Bases
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasesController<TEntity, TRepository> : ControllerBase
        where TEntity : class, IEntity
        where TRepository : class, IRepository<TEntity>
    {
        private readonly TRepository _repository;

        public BasesController(TRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var getall = await _repository.Get();
            getall = getall.Where(a => a.IsDelete.Equals(false));
            return Ok(getall);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Get(int Id)
        {
            var get = await _repository.Get(Id);
            if (get == null)
            {
                return NotFound();
            }
            return Ok(get);
        }

        [HttpPost]
        public async Task<IActionResult> Post(TEntity entity)
        {
            entity.Create();
            var create = await _repository.Post(entity);
            if (create > 0)
            {
                return Ok(entity);
            }
            return BadRequest();
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Put(int Id, TEntity entity)
        {
            //var ent = await _repository.Get(Id);
            entity.Id = Id;
            entity.Update();
            var put = await _repository.Put(entity);
            if (put == true)
            {
                return Ok("Update Success");
            }
            return BadRequest("Update Failed");
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> HardDelete(int Id)
        {
            var delete = await _repository.Delete(Id);
            if (delete == true)
            {
                return Ok("Hard Delete Success");
            }
            return BadRequest("Hard Delete Failed");
        }

        [HttpDelete("Delete/{Id}")]
        public async Task<IActionResult> SoftDelete(int Id)
        {
            var entity = await _repository.Get(Id);
            entity.Delete();
            var delete = await _repository.Put(entity);
            if (delete == true)
            {
                return Ok("Soft Delete Success");
            }
            return BadRequest("Soft Delete Failed");
        }
    }
}