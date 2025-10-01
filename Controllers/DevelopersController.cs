using System.Data.Common;
using Microsoft.AspNetCore.Mvc;
using webApiDotNetTrainingGround.Models;

namespace webApiDotNetTrainingGround.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class DevelopersController : ControllerBase
    {
        private static List<Developer> _db = new List<Developer>();

        [HttpGet]
        public ActionResult<List<Developer>> GetAllDevelopers()
        {
            return Ok(_db);
        }

        [HttpGet("{id}")]
        public ActionResult<Developer> GetDeveloperById(int id)
        {
            var developer = _db.FirstOrDefault(d => d.Id == id);
            if (developer == null)
            {
                return NotFound();
            }
            return Ok(developer);
        }

        [HttpPost]
        public ActionResult<Developer> CreateDeveloper(Developer developer)
        {
            developer.Id = _db.Count > 0 ? _db.Max(d => d.Id) + 1 : 1;
            _db.Add(developer);
            return CreatedAtAction(nameof(GetDeveloperById), new { id = developer.Id }, developer);
        }
    }
}