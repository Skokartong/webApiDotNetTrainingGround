using System.Data.Common;
using Microsoft.AspNetCore.Mvc;
using webApiDotNetTrainingGround.Models;

namespace webApiDotNetTrainingGround.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class DevelopersController : ControllerBase
    {
        private List<Developer> _db;

        public DevelopersController()
        {
            _db = new List<Developer>();
        }

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
    }
}