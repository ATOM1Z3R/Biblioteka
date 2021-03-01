using Biblioteka.Models;
using System.Collections.Generic;

namespace BibliotekaTesty.SeedData
{
    public static class BookSeed
    {
        public static List<Book> books = new List<Book>
        {
            new Book{BookId = 1, Name="Book1", Description = "Sample desc 1", ReleaseDate = new System.DateTime(2000,01,02), Author = AuthorSeed.authors[0]}, 
            new Book{BookId = 2, Name="Book2", Description = "Sample desc 2", ReleaseDate = new System.DateTime(2010,01,02), Author = AuthorSeed.authors[1]},
        };
    }
}
