using Biblioteka.BLL.AuthorBLL.Interfaces;
using Biblioteka.Data;
using Biblioteka.Models;
using System.Collections.Generic;

namespace Biblioteka.BLL.AuthorBLL
{
    public class ReadListAuthorData : IReadListAuthorData
    {
        private readonly ApplicationDbContext _context;

        public ReadListAuthorData(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Author> ReadAllAuthors()
        {
            return _context.Authors;
        }
    }
}
