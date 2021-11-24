using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Web.BookStore.Models
{
  /// <summary>
  /// Клиент
  /// </summary>
  public class Client : IPerson
  {
    #region PropertiesIPerson
    public string FullName { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public DateTime DateBirth { get; set; }
    #endregion

    /// <summary>
    /// ID клиента
    /// </summary>
    public Guid PurchaseId { get; set; }
    
    /// <summary>
    /// Адрес покупателя
    /// </summary>
    public string Address { get; set; }
    /// <summary>
    /// Почта
    /// </summary>
    public string Email { get; set; }
    /// <summary>
    /// Телефон
    /// </summary>
    public string Phone { get; set; }


  }
}
