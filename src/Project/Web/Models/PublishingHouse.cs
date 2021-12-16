using System;
using System.Collections.Generic;

namespace BookStore.Web.BookStore.Models
{
  /// <summary>
  /// Издательство
  /// </summary>
  public class PublishingHouse
  {
    /// <summary>
    /// Издательство ID
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// Имя Издательства
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// Книги
    /// </summary>
    public List<Book> Books { get; set; } = new List<Book>();
  }
}
