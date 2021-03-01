using System.Threading.Tasks;

namespace Biblioteka.BLL.BookBLL.Interfaces
{
    public interface IDeleteData
    {
        Task DeleteBookAsync(int id);
    }
}
