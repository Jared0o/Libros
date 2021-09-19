using Core.Entities;
using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Data.Seeds
{
    public static class SeedDate
    {
        public async static Task Seed(UserManager<User> userManager, LibrosContext context)
        {
            var admin = await userManager.FindByEmailAsync("admin@jarek.pl");
            List<Author> authors = new List<Author>
                {
                    new Author{FirstName = "Adam", LastName = "Mickiewicz", DateOfBirth = DateTime.Now.AddDays(-1), CreatedBy = admin, NormalizedName = "ADAM MICKIEWICZ" },
                    new Author{FirstName = "Henryk", LastName = "Sienkiewicz", DateOfBirth = DateTime.Now.AddDays(-1), CreatedBy = admin, NormalizedName = "HENRYK SIENKIEWICZ" },
                    new Author{FirstName = "J.K", LastName = "Rowling", DateOfBirth = DateTime.Now.AddDays(-1), CreatedBy = admin, NormalizedName = "J.K ROWLING" }
                };
            List<Publisher> publishers = new List<Publisher>
                {
                    new Publisher{Name = "Greg", Website = "www.greg.pl", CreatedBy  = admin},
                    new Publisher{Name = "Znak", Website = "www.znak.pl", CreatedBy  = admin},
                    new Publisher{Name = "Agora", Website = "www.agora.pl", CreatedBy  = admin}
                };

            List<Book> books = new List<Book>
                {
                    new Book{Name = "Pan Tadeusz", Author = authors[0], Age = 1994, Isbn = "13245687", Pages = 145, Publisher = publishers[0], CreatedBy = admin},
                    new Book{Name = "W Pustyni i w Puszczy", Author = authors[1], Age = 1874, Isbn = "9874561285", Pages = 210, Publisher = publishers[1], CreatedBy = admin},
                    new Book{Name = "Harry Potter", Author = authors[2], Age = 2000, Isbn = "4548746435648", Pages = 665, Publisher = publishers[2], CreatedBy = admin},
                };

            if (!context.Authors.Any())
            {

                await context.Authors.AddRangeAsync(authors);

            }

            if (!context.Publishers.Any())
            {

                await context.Publishers.AddRangeAsync(publishers);
            }

            if (!context.Books.Any())
            {
                await context.Books.AddRangeAsync(books);
            }


            await context.SaveChangesAsync();
        }
    }
}
