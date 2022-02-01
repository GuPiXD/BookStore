using System;
using System.Collections.Generic;
using BookStore.Data.DataDB.DAL.Models;
using BookStore.Data.DataDB.DAL;

namespace BookStore.Data.DataDB
{
  public static class SampleData
  {
    public static void Initialize(BookLibraryDbContext context)
    {
      InitializeData(context);      
      context.SaveChanges();
    }


    private static void InitializeData(BookLibraryDbContext context)
    {
        var ivanov = new Client
                     {
                       Id = Guid.NewGuid(),
                       Address = "г.Коломна,Учебный переулок, дом 100, кв. 15",
                       Email = "IvanovII@yandex.ru",
                       Phone = "+7(915)351-56-41",
                       FirstName = "Ivan",
                       LastName = "Ivanov",
                       Job = "Intern",
                     
                     };
        var andreevich = new Client
                         {
                           Id = Guid.NewGuid(),
                           Address = "г.Москва,ул. Мира, дом 15, кв. 100",
                           Email = "IvanovII@yandex.ru",
                           Phone = "+7(960)595-22-11",
                           FirstName = "Andrey",
                           LastName = "Andreevich",
                         };

        context.Clients.AddRange(ivanov, andreevich);

        var ACT = new PublishingHouse { Id = Guid.NewGuid(), Name = "АСТ" };
        var AbcSP = new PublishingHouse { Id = Guid.NewGuid(), Name = "Азбука СПб" };
        var gaiman = new Author
        {
          Id = Guid.NewGuid(),
          FirstName = "Нил",
          LastName = "Гейман",
          Rating = 8
        };
        var pratchett = new Author
        {
          Id = Guid.NewGuid(),
          FirstName = "Теренс",
          LastName = "Пратчетт",
          Rating = 7
        };

        var sandman = new Book
        {
          PublishingHouse = AbcSP,
          NumberPages = 272,
          Authors = new List<Author>() { gaiman },
          ISBN = "978-5-389-09098-9",
          Name = "The Sandman. Песочный человек. Книга 1. Прелюдии и ноктюрны",
          Price = 934d
        };
        var scandinavianGods = new Book
        {
          PublishingHouse = AbcSP,
          NumberPages = 320,
          Authors = new List<Author>() { gaiman },
          ISBN = "978-5-17-119215-0",
          Name = "Скандинавские боги",
          Price = 452d
        };
        var pyramids = new Book
        {
          PublishingHouse = ACT,
          NumberPages = 416,
          Authors = new List<Author>() { pratchett },
          ISBN = "978-5-699-16835-4",
          Name = "Пирамиды",
          Price = 452d
        };
        var apprenticeDeath = new Book
        {
          PublishingHouse = ACT,
          NumberPages = 384,
          Authors = new List<Author>() { pratchett },
          ISBN = "978-5-699-22357-2",
          Name = "Мор, ученик Смерти",
          Price = 452d
        };

        context.PublishingHouses.AddRange(ACT, AbcSP);
        context.Books.AddRange(sandman, scandinavianGods, pyramids, apprenticeDeath);
        context.Authors.AddRange(gaiman, pratchett);

        context.CheckoutHistories.Add(new CheckoutHistory
        {
          Book = scandinavianGods,
          Client = ivanov,
          CheckoutDate = DateTime.Now
        });

        context.CheckoutHistories.Add(new CheckoutHistory
        {
          Book = pyramids,
          Client = ivanov,
          CheckoutDate = DateTime.Now
        });      
    }
  }
}
