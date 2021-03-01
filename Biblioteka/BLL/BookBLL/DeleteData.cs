using Biblioteka.BLL.BookBLL.Interfaces;
using Biblioteka.Data;
using Biblioteka.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteka.BLL.BookBLL
{
    public class DeleteData : IDeleteData
    {
        private readonly ApplicationDbContext _context;

        public DeleteData(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task DeleteBookAsync(int id)
        {
            var book = await _context.Books.FindAsync(id);
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
        }
    }
}
