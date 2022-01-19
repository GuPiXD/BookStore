using System;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Data.DataDB.DAL.Models
{
  /// <summary>
  /// История покупоки
  /// </summary>
  public class CheckoutHistory
  {
    /// <summary>
    /// ID Истори покупоки
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// Клиент
    /// </summary>
    [Required]
    public Client Client { get; set; }
    /// <summary>
    /// Книга
    /// </summary>
    [Required]
    public Book Book { get; set; }
    /// <summary>
    /// Дата оформления заказа
    /// </summary>
    public DateTime CheckoutDate { get; set; }
    /// <summary>
    /// Дата возврата покупки - не обязательное поле Null
    /// </summary>
    public DateTime? ReturnDate { get; set; }
  }
}
