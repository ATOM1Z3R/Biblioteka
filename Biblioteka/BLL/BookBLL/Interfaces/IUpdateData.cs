using Biblioteka.Models;
using System.Threading.Tasks;

namespace Biblioteka.BLL.BookBLL.Interfaces
{
    public interface IUpdateData
    {
        Task<bool> UpdateBookAsync(int id, Book book);
    }
}
