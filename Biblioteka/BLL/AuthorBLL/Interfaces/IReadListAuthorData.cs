using Biblioteka.Models;
using System.Collections.Generic;

namespace Biblioteka.BLL.AuthorBLL.Interfaces
{
    public interface IReadListAuthorData
    {
        IEnumerable<Author> ReadAllAuthors();
    }
}
