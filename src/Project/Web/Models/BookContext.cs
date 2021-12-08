using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Web.BookStore.Models
{
  public class BookContext:DbContext
  {
    public DbSet<Book> Books { get; set; }
    public DbSet<CheckoutHistory> CheckoutHistorys { get; set; }
    public BookContext(DbContextOptions<BookContext> options) : base(options)
    {
      Database.EnsureCreated();
    }

  }
}
