using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Web.BookStore.Models
{
  /// <summary>
  /// Автор
  /// </summary>
  public class Author : IPerson
  {
    #region PropertiesIPerson
    public string FullName { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public DateTime DateBirth { get; set; }
    #endregion

    /// <summary>
    /// ID книги
    /// </summary>
    public Guid AuthorId { get; set; }
    public Guid[] BookId { get; set; }
    /// <summary>
    /// Рейтинг - не обязательное поле Null
    /// </summary>
    public int Rating { get; set; }
  }
}
