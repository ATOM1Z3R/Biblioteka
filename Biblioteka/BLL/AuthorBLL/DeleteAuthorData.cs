using Biblioteka.BLL.AuthorBLL.Interfaces;
using Biblioteka.Data;
using System.Threading.Tasks;

namespace Biblioteka.BLL.AuthorBLL
{
    public class DeleteAuthorData : IDeleteAuthorData
    {
        private readonly ApplicationDbContext _context;

        public DeleteAuthorData(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task DeleteAuthorAsync(int id)
        {
            var author = await _context.Authors.FindAsync(id);
            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();
        }
    }
}
