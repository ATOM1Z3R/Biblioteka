using Biblioteka.Data;
using BibliotekaTesty.SeedData;
using Microsoft.EntityFrameworkCore;
using System;

namespace BibliotekaTesty
{
    public class TestBase : IDisposable
    {
        protected readonly ApplicationDbContext _context;

        public TestBase()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            _context = new ApplicationDbContext(options);
            _context.Database.EnsureCreated();
            _context.AddRange(BookSeed.books);
            _context.AddRange(AuthorSeed.authors);
            _context.AddRange(ReservationSeed.reservations);
            _context.AddRange(UserSeed.users);
        }

        public void Dispose()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }
    }
}
