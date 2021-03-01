using Biblioteka.Models;
using System.Threading.Tasks;

namespace Biblioteka.BLL.BookBLL.Interfaces
{
    public interface IWriteData
    {
        Task<Book> AddBookAsync(Book book);
    }
}
