using System.Collections.Generic;
using Biblioteka.Models;

namespace Biblioteka.BLL.BookBLL.Interfaces
{
    public interface IReadListData
    {
        IEnumerable<Book> ReadAllBooks();
    }
}
