using Biblioteka.BLL.BookBLL.Interfaces;
using Biblioteka.Data;
using Biblioteka.Models;
using System.Threading.Tasks;

namespace Biblioteka.BLL.BookBLL
{
    public class WriteData : IWriteData
    {
        private readonly ApplicationDbContext _context;

        public WriteData(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Book> AddBookAsync(Book book)
        {
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
            return book;
        }
    }
}
