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
        public ActionResult<Developer> CreateDeveloper(Developer developer)
        {
            developer.Id = _db.Developers.Count > 0 ? _db.Developers.Max(d => d.Id) + 1 : 1;
            _db.Developers.Add(developer);
            return CreatedAtAction(nameof(GetDeveloperById), new { id = developer.Id }, developer);
        }
    }
}