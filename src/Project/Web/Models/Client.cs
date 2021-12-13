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
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public DateTime DateBirth { get; set; }
    #endregion
    /// <summary>
    /// ID клиента
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// Адрес клиента
    /// </summary>
    public string Address { get; set; }
    /// <summary>
    /// Электронная Почта
    /// </summary>
    public string Email { get; set; }
    /// <summary>
    /// Телефон
    /// </summary>
    public string Phone { get; set; }
  }
}
