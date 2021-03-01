using Biblioteka.BLL.BookBLL.Interfaces;
using Biblioteka.Data;
using Biblioteka.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteka.BLL.BookBLL
{
    public class ReadDetailData : IReadDetailData
    {
        private readonly ApplicationDbContext _context;

        public ReadDetailData(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Book> ReadBookDetailAsync(int id)
        {
            var book = await _context.Books.Include(x => x.Author)
                                           .FirstOrDefaultAsync(x => x.BookId == id);
            return book;
        }

        public async Task<Book> ReadBookReservationsAsync(int id)
        {
            var book = await _context.Books.Include(x => x.Author)
                                           .Include(x => x.Reservation).ThenInclude(y => y.User)
                                           .FirstOrDefaultAsync(x => x.BookId == id);
            return book;
        }
    }
}
