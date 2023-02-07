using GitRepoInfoTestTask.Models;
using LibGit2Sharp;
using Microsoft.AspNetCore.Mvc;

namespace GitRepoInfoTestTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private readonly Repository _repository = new Repository(RepositoryConnection.ConnectionPath);

        [HttpGet]
        public IActionResult GetAll()
        {
            var tags = _repository.Tags;

            if (tags == null)
                return NotFound();

            var tagsDto = new List<TagDTO>();

            foreach (var tag in tags)
            {
                var dto = new TagDTO()
                {
                    Name = tag.FriendlyName,
                    Author = tag.IsAnnotated ? tag.Annotation.Tagger.Name : "",
                    Message = tag.IsAnnotated ? tag.Annotation.Message.Replace("\n", "") : "" // Использую Replace, так как на конце сообщения остается \n, которое видно в JSON
                };

                tagsDto.Add(dto);
            }

            return Ok(tagsDto);
        }
    }
}
