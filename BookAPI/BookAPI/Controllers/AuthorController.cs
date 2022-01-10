using BookAPI.Model;
using BookAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {

        private readonly IAuthorRepository _authorRepository;

        public AuthorController(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Author>> GetAuthors()
        {
            return await _authorRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Author>> GetAuthors(int id)
        {
            return await _authorRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Author>> PostAuthors([FromBody] Author author)
        {
            var newAuthor = await _authorRepository.Create(author);
            return CreatedAtAction(nameof(GetAuthors), new { id = newAuthor.Id }, newAuthor);
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult> Delete(int id)
        {
            var authorToDelete = await _authorRepository.Get(id);

            if (authorToDelete == null)
                return NotFound();

            await _authorRepository.Delete(authorToDelete.Id);
            return NoContent();


        }

        [HttpPut]
        public async Task<ActionResult> PutAuthors(int id, [FromBody] Author author)
        {
            if (id != author.Id)
                return BadRequest();

            await _authorRepository.Update(author);

            return NoContent();
        }
    }
}
