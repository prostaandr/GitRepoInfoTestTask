using GitRepoInfoTestTask.Models;
using LibGit2Sharp;
using Microsoft.AspNetCore.Mvc;

namespace GitRepoInfoTestTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchesController : ControllerBase
    {
        private readonly Repository _repository = new Repository("C:\\Users\\prost\\source\\repos\\AppForTestTask");

        [HttpGet]
        public IActionResult GetAll()
        {
            var branches = _repository.Branches;

            if (branches == null)
                return NotFound();

            var branchesDto = new List<BranchDTO>();

            foreach (var branch in branches)
            {
                var dto = new BranchDTO()
                {
                    Name = branch.FriendlyName
                };

                branchesDto.Add(dto);

            }

            return Ok(branchesDto);
        }
    }
}
