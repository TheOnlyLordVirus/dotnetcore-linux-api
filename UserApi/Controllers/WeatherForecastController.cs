using Microsoft.AspNetCore.Mvc;

namespace UserApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DatabaseSampleController : ControllerBase
    {
        private readonly ILogger<DatabaseSampleController> _logger;

        public DatabaseSampleController(ILogger<DatabaseSampleController> logger)
        {
            _logger = logger;
        }

        [HttpPost(Name = "DebugPostValue")]
        public IEnumerable<DatabaseSampleController> Get()
        {
            return 
        }
    }
}