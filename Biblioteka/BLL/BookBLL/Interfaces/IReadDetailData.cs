using Biblioteka.Models;
using System.Threading.Tasks;

namespace Biblioteka.BLL.BookBLL.Interfaces
{
    public interface IReadDetailData
    {
        Task<Book> ReadBookDetailAsync(int id);
        Task<Book> ReadBookReservationsAsync(int id);
    }
}
