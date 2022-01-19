using System;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Data.DataDB.DAL.Models
{
  /// <summary>
  /// Клиент
  /// </summary>
  public class Client : Person
  {
    /// <summary>
    /// Адрес
    /// </summary>
    [Required(ErrorMessage = "Address is required to register")]
    public string Address { get; set; }

    /// <summary>
    /// Электронная почта
    /// </summary>
    [Required(ErrorMessage = "E-mail Address is required to register")]
    [EmailAddress(ErrorMessage = "Not a valid e-mail address")]
    [Display(Name = "E-mail address")]
    public string Email { get; set; }

    /// <summary>
    /// Телефон
    /// </summary>
    [Required(ErrorMessage = "Phone number is required to register")]
    [Phone(ErrorMessage = "Not a valid phone number")]
    [Display(Name = "Phone number")]
    public string Phone { get; set; }
    /// <summary>
    /// Работа
    /// </summary>
    public string Job { get; set; }
  }
}
