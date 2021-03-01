using Biblioteka.BLL.BookBLL;
using Biblioteka.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace BibliotekaTesty
{
    public class BookBLLTests : TestBase
    {
        [Fact]
        public void ReadListData_ShouldReturnAllData()
        {
            var readAllBooks = new ReadListData(_context);

            var expected = _context.Books;
            var actual = readAllBooks.ReadAllBooks();

            Assert.Equal(expected.Count(), actual.Count());
        }

        [Fact]
        public async Task WriteData_ShouldCreateNewRecord()
        {
            var writeData = new WriteData(_context);
            var expected = new Book { BookId = 101, Name = "Book55", Description = "Desc55" };

            await writeData.AddBookAsync(expected);
            var actual = await _context.Books.FindAsync(101);

            Assert.Same(expected, actual);
        }

        [Fact]
        public async Task DeleteData_ShouldRemoveRecordAsync()
        {
            var deleteData = new DeleteData(_context);
            var id = 2;
            await deleteData.DeleteBookAsync(id);
            var shouldBeNull = await _context.Books.FindAsync(id);

            Assert.Null(shouldBeNull);
        }

        [Fact]
        public async Task UpdateBookData_ShouldUpdateRecord()
        {
            var updateData = new UpdateData(_context);
            var bookId = 1;
            var book = _context.Books.Find(bookId);
            var NewName = "New value 1";
            book.Name = NewName;
            await updateData.UpdateBookAsync(book.BookId, book);

            var updated = _context.Books.Find(bookId);
            Assert.Equal(updated.Name, NewName);
        }
    }
}
