using Biblioteka.BLL.AuthorBLL;
using Biblioteka.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BibliotekaTesty
{
    public class AuthorBLLTests : TestBase
    {
        [Fact]
        public void ReadListAuthorData_ShouldReturnAllData()
        {
            var readAllAuthors = new ReadListAuthorData(_context);

            var expected = _context.Authors;
            var actual = readAllAuthors.ReadAllAuthors();

            Assert.Equal(expected.Count(), actual.Count());
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public async Task ReadDetailAuthorData_ShouldReturnCorrectRecord(int id)
        {
            var readDetailAuthor = new ReadDetailAuthorData(_context);

            var expected = await _context.Authors.FindAsync(id);
            var actual = await readDetailAuthor.ReadAuthorDetailAsync(id);

            Assert.Equal(expected.AuthorId, actual.AuthorId);
            Assert.Equal(expected.FirstName, actual.FirstName);
            Assert.Equal(expected.LastName, actual.LastName);
        }

        [Fact]
        public async Task WriteAuthorData_ShouldCreateNewRecord()
        {
            var writeData = new WriteAuthorData(_context);
            var expected = new Author { AuthorId = 101, FirstName = "author55", LastName = "lastname55" };

            await writeData.AddAuthorAsync(expected);
            var actual = await _context.Authors.FindAsync(101);

            Assert.Same(expected, actual);
        }

        [Fact]
        public async Task DeleteAuthorData_ShouldRemoveRecordAsync()
        {
            var deleteData = new DeleteAuthorData(_context);
            var id = 2;
            await deleteData.DeleteAuthorAsync(id);
            var shouldBeNull = await _context.Authors.FindAsync(id);

            Assert.Null(shouldBeNull);
        }

        [Fact]
        public async Task UpdateAuthorData_ShouldUpdateRecord()
        {
            var updateData = new UpdateAuthorData(_context);
            var authorId = 1;
            var author = _context.Authors.Find(authorId);
            var NewName = "New value 1";
            author.FirstName = NewName;
            await updateData.UpdateAuthorAsync(author.AuthorId, author);

            var updated = _context.Authors.Find(authorId);
            Assert.Equal(updated.FirstName, NewName);
        }
    }
}
