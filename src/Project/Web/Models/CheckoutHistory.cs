using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Web.BookStore.Models
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
    /// Id Клиента
    /// </summary>
    public Client Client { get; set; }
    /// <summary>
    /// Id Книги
    /// </summary>
    public List<Book> Book { get; set; }
    /// <summary>
    /// Дата оформления заказа
    /// </summary>
    public DateTime CheckoutDate { get; set; }
    /// <summary>
    /// Дата возврата покупки - не обязательное поле Null
    /// </summary>
    public DateTime ReturnDate { get; set; }

    public void ImplementSeed()
    {
      throw new Exception();
    }
  }
}
