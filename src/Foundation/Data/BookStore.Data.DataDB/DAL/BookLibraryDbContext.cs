using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using BookStore.Data.DataDB.DAL.Models;

namespace BookStore.Data.DataDB.DAL
{
  public class BookLibraryDbContext : DbContext
  {
    public BookLibraryDbContext(DbContextOptions<BookLibraryDbContext> options) : base(options)
    {
      Database.EnsureCreated();
    }
    public DbSet<Book> Books { get; set; }
    public DbSet<Person> People { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<CheckoutHistory> CheckoutHistories { get; set; }
    public DbSet<PublishingHouse> PublishingHouses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Author>().ToTable("Authors");
      modelBuilder.Entity<Client>().ToTable("Clients");
    }
  }
}
