using Biblioteka.Models;
using System.Collections.Generic;

namespace BibliotekaTesty.SeedData
{
    public static class AuthorSeed
    {
        public static List<Author> authors = new List<Author>
        {
            new Author{AuthorId=1, FirstName = "firstname1", LastName = "lastname1"},
            new Author{AuthorId=2, FirstName = "firstname2", LastName = "lastname2"},
            new Author{AuthorId=3, FirstName = "firstname3", LastName = "lastname3"},
        };
    }
}
