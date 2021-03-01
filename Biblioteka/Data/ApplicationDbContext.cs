using Biblioteka.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Biblioteka.Data
{
    public class ApplicationDbContext : IdentityDbContext<User, IdentityRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public ApplicationDbContext()
        {

        }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }
        public virtual DbSet<Author> Authors { get; set; }
    }
}
