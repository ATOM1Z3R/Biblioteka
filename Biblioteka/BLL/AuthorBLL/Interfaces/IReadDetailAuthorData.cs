using Biblioteka.Models;
using System.Threading.Tasks;

namespace Biblioteka.BLL.AuthorBLL.Interfaces
{
    public interface IReadDetailAuthorData
    {
        Task<Author> ReadAuthorDetailAsync(int id);
    }
}
