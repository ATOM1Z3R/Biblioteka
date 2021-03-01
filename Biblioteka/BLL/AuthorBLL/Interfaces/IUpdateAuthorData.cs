using Biblioteka.Models;
using System.Threading.Tasks;

namespace Biblioteka.BLL.AuthorBLL.Interfaces
{
    public interface IUpdateAuthorData
    {
        Task<bool> UpdateAuthorAsync(int id, Author author);
    }
}
