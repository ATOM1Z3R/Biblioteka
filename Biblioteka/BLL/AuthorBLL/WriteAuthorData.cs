using Biblioteka.BLL.AuthorBLL.Interfaces;
using Biblioteka.Data;
using Biblioteka.Models;
using System.Threading.Tasks;

namespace Biblioteka.BLL.AuthorBLL
{
    public class WriteAuthorData : IWriteAuthorData
    {
        private readonly ApplicationDbContext _context;

        public WriteAuthorData(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Author> AddAuthorAsync(Author author)
        {
            await _context.Authors.AddAsync(author);
            await _context.SaveChangesAsync();
            return author;
        }
    }
}
