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
    }
}