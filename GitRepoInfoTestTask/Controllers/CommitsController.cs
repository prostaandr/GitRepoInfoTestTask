using GitRepoInfoTestTask.Models;
using Microsoft.AspNetCore.Mvc;

namespace GitRepoInfoTestTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommitsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            return NotFound();
        }

        [HttpGet("{branchname}")]
        public IActionResult GetByBranch(BranchDTO branch)
        {
            return NotFound();
        }
    }
}
