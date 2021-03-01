using System.Threading.Tasks;

namespace Biblioteka.BLL.AuthorBLL.Interfaces
{
    public interface IDeleteAuthorData
    {
        Task DeleteAuthorAsync(int id);
    }
}
