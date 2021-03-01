using Biblioteka.BLL.BookBLL.Interfaces;
using Biblioteka.Data;
using Biblioteka.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Biblioteka.BLL.BookBLL
{
    public class ReadListData : IReadListData
    {
        private readonly ApplicationDbContext _context;
        public ReadListData(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Book> ReadAllBooks()
        {
            return _context.Books.Include(x=>x.Author);
        }
    }
}
