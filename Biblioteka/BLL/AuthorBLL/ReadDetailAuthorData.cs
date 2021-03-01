using Biblioteka.BLL.AuthorBLL.Interfaces;
using Biblioteka.Data;
using Biblioteka.Models;
using System.Threading.Tasks;

namespace Biblioteka.BLL.AuthorBLL
{
    public class ReadDetailAuthorData : IReadDetailAuthorData
    {
        private readonly ApplicationDbContext _context;

        public ReadDetailAuthorData(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Author> ReadAuthorDetailAsync(int id)
        {
            var author = await _context.Authors.FindAsync(id);
            return author;
        }
    }
}
