using Biblioteka.BLL.ReservationBLL.Interfaces;
using Biblioteka.Data;
using Biblioteka.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteka.BLL.ReservationBLL
{
    public class ReadListData : IReadListData
    {
        private readonly ApplicationDbContext _context;

        public ReadListData(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Reservation> ReadAllReservations()
        {
            return _context.Reservations.Include(x => x.Book).Include(x => x.User);
        }

        public IEnumerable<Reservation> ReadUserReservations(string userId)
        {
            var reservations = _context.Reservations.Include(x => x.Book)
                                                    .Where(x => x.User.Id == userId);
            return reservations;
        }
    }
}
