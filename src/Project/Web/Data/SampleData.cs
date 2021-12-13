using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Web.BookStore.Models;

namespace BookStore.Web.BookStore.Data
{
  public class SampleData
  {
    public static void Initialize(BookContext context)
    {
      InitializeClients(context);
      InitializeAuthors(context);
      InitializePublishingHouses(context);
      InitializeBooks(context);
    }


    private static void InitializeBooks(BookContext context)
    {
      if (!context.Books.Any())
      {
        var authors = context.Authors.ToList();
        var publishingHouses = context.PublishingHouses.ToList();
        context.Books.AddRange(new Book
                               {
                                 Id = Guid.NewGuid(),
                                 Authors = new List<Author>() { authors[0] } , 
                                 PublishingHouse = publishingHouses[1],
                                 BindingType = enBindingType.SuperSevenBC,
                                 NumberPages = 272,
                                 NumberBooksStock = 50,
                                 ISBN = "978-5-389-09098-9",
                                 Name = "The Sandman. Песочный человек. Книга 1. Прелюдии и ноктюрны",
                                 Series = "Графические романы",
                                 YearPublishing = new DateTime(2015,1,1),
                                 Price = 934d
                               },
                               new Book
                               {
                                 Id = Guid.NewGuid(),
                                 Authors = new List<Author>() { authors[0] } , 
                                 PublishingHouse = publishingHouses[0],
                                 BindingType = enBindingType.SevenBC,
                                 NumberPages = 320,
                                 NumberBooksStock = 10,
                                 ISBN = "978-5-17-119215-0",
                                 Name = "Скандинавские боги",
                                 Series = string.Empty,
                                 YearPublishing = new DateTime (2021, 1,1),
                                 Price = 452d
                               },
                               new Book
                               {
                                 Id = Guid.NewGuid(),
                                 Authors = new List<Author>() { authors[1] } , 
                                 PublishingHouse = publishingHouses[0],
                                 BindingType = enBindingType.SevenBC,
                                 NumberPages = 416,
                                 NumberBooksStock = 10,
                                 ISBN = "978-5-699-16835-4",
                                 Name = "Пирамиды",
                                 Series = "Плоский мир.Смерть",
                                 YearPublishing = new DateTime(2021, 1,1),
                                 Price = 452d
                               },
                               new Book
                               {
                                 Id = Guid.NewGuid(),
                                 Authors = new List<Author>() { authors[1] } , 
                                 PublishingHouse = publishingHouses[0],
                                 BindingType = enBindingType.SevenBC,
                                 NumberPages = 384,
                                 NumberBooksStock = 5,
                                 ISBN = "978-5-699-22357-2",
                                 Name = "Мор, ученик Смерти",
                                 Series = "Плоский мир.Смерть",
                                 YearPublishing = new DateTime(2020, 1,1),
                                 Price = 452d
                               }
                              );
        context.SaveChanges();
      }
    }

    private static void InitializeAuthors(BookContext context)
    {
      if (!context.Authors .Any())
      {
        context.Authors.AddRange(new Author
                                 {
                                  Id   = Guid.NewGuid(),
                                  FirstName  = "Нил",
                                  LastName   = "Гейман",
                                  MiddleName = "Ричард",
                                  DateBirth  = new DateTime(1960, 11, 10),
                                  Rating     = 8                                  
                                 },
                                 new Author
                                 {
                                  Id   = Guid.NewGuid(),
                                  FirstName  = "Теренс",
                                  LastName   = "Пратчетт",
                                  MiddleName = "Дэвид Джон",
                                  DateBirth  = new DateTime(1948, 4, 28),
                                  Rating     = 7                                  
                                 }
                                );
        context.SaveChanges();
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
                                );;
        context.SaveChanges();
      }
    }

    private static void InitializePublishingHouses(BookContext context)
    {
      if (!context.PublishingHouses.Any())
      {
        context.PublishingHouses.AddRange(new PublishingHouse
                                          {
                                           Id = Guid.NewGuid(),
                                           Name = "АСТ"
                                          },
                                          new PublishingHouse
                                          {
                                            Id = Guid.NewGuid(),
                                            Name = "Азбука СПб"
                                          }
                                         );
        context.SaveChanges();
      }
    }
  }
}
