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
        public async Task<ActionResult<List<Developer>>> GetAllDevelopers()
        {
            return Ok(new List<Developer>(_db));
        }
    }
}