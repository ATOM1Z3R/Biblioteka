using System.Threading.Tasks;

namespace Biblioteka.BLL.ReservationBLL.Interfaces
{
    public interface IWriteData
    {
        Task AddReservationAsync(int bookId, string userId);
    }
}
