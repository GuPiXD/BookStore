using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Data.DataDB.DAL.Models
{
  /// <summary>
  /// Автор
  /// </summary>
  public class Author : Person
  {
    /// <summary>
    /// Рейтинг
    /// </summary>
    [Range(1, 5)]
    public byte? Rating { get; set; }
    /// <summary>
    /// Книги
    /// </summary>
    public ICollection<Book> Books { get; set; } = new List<Book>();

    public Author()
    {
      Books = new List<Book>();
    }

  }
}
