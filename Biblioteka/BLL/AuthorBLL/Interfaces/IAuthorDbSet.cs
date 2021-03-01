using Biblioteka.Models;
using Microsoft.EntityFrameworkCore;

namespace Biblioteka.BLL.AuthorBLL.Interfaces
{
    public interface IAuthorDbSet
    {
        DbSet<Author> returnDbSetAuthor();
    }
}
