using BookAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPI.Repositories
{
    public interface IAuthorRepository
    {
        Task<IEnumerable<Author>> Get();

        Task<Author> Get(int Id);

        Task<Author> Create(Author author);

        Task Update(Author author);

        Task Delete(int Id);
    }
}
