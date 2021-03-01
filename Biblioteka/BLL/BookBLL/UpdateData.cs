using Biblioteka.BLL.BookBLL.Interfaces;
using Biblioteka.Data;
using Biblioteka.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteka.BLL.BookBLL
{
    public class UpdateData : IUpdateData
    {
        private readonly ApplicationDbContext _context;

        public UpdateData(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> UpdateBookAsync(int id, Book book)
        {
            try
            {
                _context.Update(book);
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException)
            {
                if (!_context.Books.Any(x => x.BookId == id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
            return true;
        }
    }
}
