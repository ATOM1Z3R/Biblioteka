using Biblioteka.BLL.AuthorBLL.Interfaces;
using Biblioteka.Data;
using Biblioteka.Models;
using Microsoft.EntityFrameworkCore;

namespace Biblioteka.BLL.AuthorBLL
{
    public class AuthorDbSet : IAuthorDbSet
    {
        private readonly ApplicationDbContext _context;

        public AuthorDbSet(ApplicationDbContext context)
        {
            _context = context;
        }

        public DbSet<Author> returnDbSetAuthor()
        {
            return _context.Set<Author>();
        }
    }
}
