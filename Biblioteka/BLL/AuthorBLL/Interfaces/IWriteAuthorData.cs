using Biblioteka.Models;
using System.Threading.Tasks;

namespace Biblioteka.BLL.AuthorBLL.Interfaces
{
    public interface IWriteAuthorData
    {
        Task<Author> AddAuthorAsync(Author author);
    }
}
