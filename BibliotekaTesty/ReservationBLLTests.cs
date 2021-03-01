using Biblioteka.BLL.ReservationBLL;
using Biblioteka.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BibliotekaTesty
{
    public class ReservationBLLTests : TestBase
    {
        [Fact]
        public void ReadListData_ShouldReturnAllValue()
        {
            var readListData = new ReadListData(_context);

            var expected = _context.Reservations.Count();
            var actual = readListData.ReadAllReservations().Count();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ReadListData_ShouldReturnAllUserValue()
        {
            string userId = "123";
            var readListData = new ReadListData(_context);

            var expected = _context.Reservations.Where(x => x.User.Id == userId).Count();
            var actual = readListData.ReadUserReservations(userId).Count();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public async Task WriteData_ShouldCreateNewRecord()
        {
            var userId = "111";
            var bookId = 1;
            var expected = 3;
            var writeData = new WriteData(_context);

            await writeData.AddReservationAsync(bookId, userId);
            var actual = _context.Reservations.Count();

            Assert.Equal(expected, actual);
        }
    }
}
