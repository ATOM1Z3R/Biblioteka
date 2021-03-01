using Biblioteka.Models;
using System.Collections.Generic;

namespace Biblioteka.BLL.ReservationBLL.Interfaces
{
    public interface IReadListData
    {
        IEnumerable<Reservation> ReadAllReservations();
        IEnumerable<Reservation> ReadUserReservations(string userId);
    }
}
