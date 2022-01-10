using BookAPI.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPI.Repositories
{
    public class BookRepository : IBookRepository
    {
        public readonly Model.AppContext _context;

        public BookRepository(Model.AppContext context)
        {
            _context = context;
        }
        public async Task<Book> Create(Book book)
        {
            
            _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();

            return book;
        }

        public async Task Delete(int id)
        {
            var bookToDelete = await _context.Books.FindAsync(id);
            _context.Books.Remove(bookToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Book>> Get()
        {

            return await _context.Books.ToListAsync();
        }


        public async Task<Book> Get(int id)
        {
            var BookReturn = _context.Books.FirstAsync(i => i.Id == id);
            return await BookReturn;

        }

            public async Task Update(Book book)
        {
            _context.Entry(book).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
