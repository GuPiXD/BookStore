using System;

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
    public Guid PublishingHouseId { get; set; }
    /// <summary>
    /// Имя Издательства
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// ID книг
    /// </summary>
    public Guid[] BookId { get; set; }
  }
}
