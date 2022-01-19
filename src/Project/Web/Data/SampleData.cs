using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Web.BookStore.Models;

namespace BookStore.Web.BookStore.Data
{
  public static class SampleData
  {
    public static void Initialize(BookContext context)
    {
      InitializeClients(context);
      InitializeBooks(context);
      if (!context.Books.Any() && !context.Authors.Any() && !context.PublishingHouses.Any()&& !context.Clients.Any())
        context.SaveChanges();
    }


    private static void InitializeBooks(BookContext context)
    {
      if (!context.Books.Any() && !context.Authors.Any() && !context.PublishingHouses.Any())
      {

        var ACT   = new PublishingHouse { Id = Guid.NewGuid(), Name = "АСТ" };
        var AbcSP = new PublishingHouse { Id = Guid.NewGuid(), Name = "Азбука СПб" };        
        var gaiman = new Author
        {
          Id = Guid.NewGuid(),
          FirstName = "Нил",
          LastName = "Гейман",
          MiddleName = "Ричард",
          DateBirth = new DateTime(1960, 11, 10),
          Rating = 8
        };
        var pratchett        =            new Author
        {
          Id = Guid.NewGuid(),
          FirstName = "Теренс",
          LastName = "Пратчетт",
          MiddleName = "Дэвид Джон",
          DateBirth = new DateTime(1948, 4, 28),
          Rating = 7
        };
        
        var sandman = new Book
        {
          Id = Guid.NewGuid(), 
          PublishingHouse = AbcSP,
          BindingType = enBindingType.SuperSevenBC,
          NumberPages = 272,
          NumberBooksStock = 50,
          ISBN = "978-5-389-09098-9",
          Name = "The Sandman. Песочный человек. Книга 1. Прелюдии и ноктюрны",
          Series = "Графические романы",
          YearPublishing = new DateTime(2015, 1, 1),
          Price = 934d
        };
        var scandinavianGods = new Book
        {
          Id = Guid.NewGuid(),
          PublishingHouse = AbcSP,
          BindingType = enBindingType.SevenBC,
          NumberPages = 320,
          NumberBooksStock = 10,
          ISBN = "978-5-17-119215-0",
          Name = "Скандинавские боги",
          Series = string.Empty,
          YearPublishing = new DateTime(2021, 1, 1),
          Price = 452d
        };
        var pyramids = new Book
        {
          Id = Guid.NewGuid(),
          PublishingHouse = ACT,
          BindingType = enBindingType.SevenBC,
          NumberPages = 416,
          NumberBooksStock = 10,
          ISBN = "978-5-699-16835-4",
          Name = "Пирамиды",
          Series = "Плоский мир.Смерть",
          YearPublishing = new DateTime(2021, 1, 1),
          Price = 452d
        };
        var apprenticeDeath = new Book
        {
          Id = Guid.NewGuid(),
          PublishingHouse = ACT,
          BindingType = enBindingType.SevenBC,
          NumberPages = 384,
          NumberBooksStock = 5,
          ISBN = "978-5-699-22357-2",
          Name = "Мор, ученик Смерти",
          Series = "Плоский мир.Смерть",
          YearPublishing = new DateTime(2020, 1, 1),
          Price = 452d
        };

        sandman.AuthorBooks          = new List<AuthorBook> { new AuthorBook { Author = gaiman, AuthorId = gaiman.Id, Book = sandman, BookId = sandman.Id } };
        scandinavianGods.AuthorBooks = new List<AuthorBook> { new AuthorBook { Author = gaiman, AuthorId = gaiman.Id, Book = scandinavianGods, BookId = scandinavianGods.Id } };
        pyramids.AuthorBooks         = new List<AuthorBook> { new AuthorBook { Author = pratchett, AuthorId = pratchett.Id, Book = pyramids, BookId = pyramids.Id } };
        apprenticeDeath.AuthorBooks  = new List<AuthorBook> { new AuthorBook { Author = pratchett, AuthorId = pratchett.Id, Book = apprenticeDeath, BookId = apprenticeDeath.Id } };

        context.PublishingHouses.AddRange(ACT, AbcSP);
        context.Books.AddRange(sandman, scandinavianGods, pyramids, apprenticeDeath);
        context.Authors.AddRange(gaiman, pratchett);        
      }
    }

    private static void InitializeClients(BookContext context)
    {
      if (!context.Clients.Any())
      {
        context.Clients.AddRange(new Client
                                 {
                                   Id   = Guid.NewGuid(),
                                   Address    = "г.Коломна,Учебный переулок, дом 100, кв. 15",
                                   Email      = "IvanovII@yandex.ru",
                                   Phone      = "+7(915)351-56-41",
                                   FirstName  = "Ivan",
                                   LastName   = "Ivanov",
                                   MiddleName = "Ivanovich"
                                 },
                                 new Client
                                 {
                                   Id   = Guid.NewGuid(),
                                   Address    = "г.Москва,ул. Мира, дом 15, кв. 100",
                                   Email      = "IvanovII@yandex.ru",
                                   Phone      = "+7(960)595-22-11",
                                   FirstName  = "Andrey",
                                   LastName   = "Andreevich",
                                   MiddleName = "Andreev",
                                   DateBirth  = new DateTime(1995,6,3)
                                 }
                                );
      }
    }
  }
}
