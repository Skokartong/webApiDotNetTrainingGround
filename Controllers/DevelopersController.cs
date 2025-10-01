using System.Data.Common;
using Microsoft.AspNetCore.Mvc;
using webApiDotNetTrainingGround.Models;

namespace webApiDotNetTrainingGround.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class DevelopersController : ControllerBase
    {
        private Db _db;
        public DevelopersController(Db db)
        {
            _db = db;
        }

        [HttpGet]
        public ActionResult<List<Developer>> GetAllDevelopers()
        {
            return Ok(_db.Developers);
        }

        [HttpGet("{id}")]
        public ActionResult<Developer> GetDeveloperById(int id)
        {
            var developer = _db.Developers.FirstOrDefault(d => d.Id == id);
            if (developer == null)
            {
                return NotFound();
            }
            return Ok(developer);
        }

        [HttpPost]
        public ActionResult<Developer> CreateDeveloper(CreateDeveloperRequest request)
        {
            var newDeveloper = new Developer
            {
                Id = _db.Developers.Count + 1,
                Name = request.Name,
                Role = request.Role,
                Experience = request.Experience
            };
            _db.Developers.Add(newDeveloper);
            return CreatedAtAction(nameof(GetDeveloperById), new { id = newDeveloper.Id }, newDeveloper);
        }
    }
}