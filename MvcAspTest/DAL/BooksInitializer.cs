using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using BootstrapIntroduction.Models;

namespace BootstrapIntroduction.DAL
{
    public class BooksInitializer : DropCreateDatabaseIfModelChanges<BookContext>
        {
            protected override void Seed(BookContext context)
            {
                var author = new Author
                {
                    biography = "...",
                    firstName = "Bruce",
                    lastName = "Wayne"
                };

                var books = new List<Book>
                {
                    new Book
                    {
                        author = author,
                        descritpion = "...",
                        imageUrl = "http://ecx.images-amazon.com/images/I/51T%2BWt430bL._AA160_.jpg",
                        isbn = "123456789",
                        synopsis = "...",
                        title = "Knockout.js in 5 minutes"
                    },
                    new Book
                    {
                        author = author,
                        descritpion = "...",
                        imageUrl = "http://ecx.images-amazon.com/images/I/51T%2BWt430bL._AA160_.jpg",
                        isbn = "123456789",
                        synopsis = "...",
                        title = "Knockout.js in 10 years"
                    }
                };

                books.ForEach(b => context.books.Add(b));
                context.SaveChanges();
            }
        }
}