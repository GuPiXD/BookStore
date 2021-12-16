using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Web.BookStore.Models;

namespace BookStore.Web.BookStore.Data
{
  public class BookContext:DbContext
  {
    public DbSet<Book> Books { get; set; }
    public DbSet<CheckoutHistory> CheckoutHistorys { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<PublishingHouse> PublishingHouses { get; set; }

    public BookContext(DbContextOptions<BookContext> options)
    : base(options)
    {
      Database.EnsureDeleted();   // удалем базу данны при первом оборащении
      Database.EnsureCreated();   // создаем базу данных при первом обращении
    }

  }
}
