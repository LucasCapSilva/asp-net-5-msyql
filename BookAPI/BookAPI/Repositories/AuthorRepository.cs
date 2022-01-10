using BookAPI.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPI.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        public readonly Model.AppContext _context;

        public AuthorRepository(Model.AppContext context)
        {
            _context = context;
        }

        public async Task<Author> Create(Author author)
        {
            _context.Authors.Add(author);
            await _context.SaveChangesAsync();

            return author;
        }

        public async Task Delete(int id)
        {
            var authoroDelete = await _context.Authors.FindAsync(id);
            _context.Authors.Remove(authoroDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Author>> Get()
        {
            return await _context.Authors.ToListAsync();
        }

        public async Task<Author> Get(int id)
        {
            var AuthorReturn = _context.Authors.FirstAsync(i => i.Id == id);
            return await AuthorReturn;

        }

        public async Task Update(Author author)
        {
            _context.Entry(author).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
