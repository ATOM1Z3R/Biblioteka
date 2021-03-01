using Biblioteka.BLL.AuthorBLL.Interfaces;
using Biblioteka.Data;
using Biblioteka.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Biblioteka.BLL.AuthorBLL
{
    public class UpdateAuthorData : IUpdateAuthorData
    {
        private readonly ApplicationDbContext _context;

        public UpdateAuthorData(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> UpdateAuthorAsync(int id, Author author)
        {
            try
            {
                _context.Update(author);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
            return true;
        }
    }
}
