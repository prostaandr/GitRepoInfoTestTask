using Microsoft.AspNetCore.Mvc;

namespace GitRepoInfoTestTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchesController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            return NotFound();
        }
    }
}
