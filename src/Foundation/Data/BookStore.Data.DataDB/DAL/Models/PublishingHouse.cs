using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Data.DataDB.DAL.Models
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
    [Required]
    public string Name { get; set; }
    /// <summary>
    /// Книги
    /// </summary>
    [Required]
    public ICollection<Book> Books { get; set; }

    public PublishingHouse()
    {
      Books = new List<Book>();
    }
  }
}
