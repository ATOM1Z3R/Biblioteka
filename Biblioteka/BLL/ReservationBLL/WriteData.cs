using Biblioteka.BLL.ReservationBLL.Interfaces;
using Biblioteka.Data;
using Biblioteka.Models;
using System.Threading.Tasks;

namespace Biblioteka.BLL.ReservationBLL
{
    public class WriteData : IWriteData
    {
        private readonly ApplicationDbContext _context;

        public WriteData(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddReservationAsync(int bookId, string userId)
        {
            Reservation reservation = new Reservation { 
                Book = await _context.Books.FindAsync(bookId),
                User = await _context.Users.FindAsync(userId),
            };
            await _context.Reservations.AddAsync(reservation);
            await _context.SaveChangesAsync();
        }
    }
}
