using GitRepoInfoTestTask.Models;
using LibGit2Sharp;
using Microsoft.AspNetCore.Mvc;

namespace GitRepoInfoTestTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommitsController : ControllerBase
    {
        private readonly Repository _repository = new Repository(RepositoryConnection.ConnectionPath);

        [HttpGet]
        public IActionResult GetAll()
        {
            var commits = _repository.Commits.QueryBy(new CommitFilter { IncludeReachableFrom = _repository.Refs });

            if (commits == null)
                return NotFound();

            var commitsDto = new List<CommitDTO>();

            foreach (var commit in commits)
            {
                var dto = new CommitDTO()
                {
                    Author = commit.Author.Name,
                    CreateDate = commit.Committer.When.DateTime,
                    Message = commit.Message.Replace("\n", "") // Использую Replace, так как на конце сообщения остается \n, которое видно в JSON
                };

                commitsDto.Add(dto);
            }

            return Ok(commitsDto);
        }

        [HttpGet("{branchname}")]
        public IActionResult GetByBranch(string branchname)
        {
            var branch = _repository.Branches.Where(b => b.FriendlyName == branchname).FirstOrDefault();

            if (branch == null)
                return NotFound();

            var commits = branch.Commits;

            var commitsDto = new List<CommitDTO>();

            foreach (var commit in commits)
            {
                var dto = new CommitDTO()
                {
                    Author = commit.Author.Name,
                    CreateDate = commit.Committer.When.DateTime,
                    Message = commit.Message.Replace("\n", "") // Использую Replace, так как на конце сообщения остается \n, которое видно в JSON
                };

                commitsDto.Add(dto);
            }

            return Ok(commitsDto);

        }
    }
}
