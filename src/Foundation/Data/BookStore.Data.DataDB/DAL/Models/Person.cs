using System;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Data.DataDB.DAL.Models
{
  /// <summary>
  /// Человек
  /// </summary>
  public abstract class Person
  {
    /// <summary>
    /// ID человека
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// Имя
    /// </summary>
    [Required(ErrorMessage = "First Name is required to register")]
    [StringLength(40, ErrorMessage = "First Name is too long")]
    [Display(Name = "First Name")]
    public string FirstName { get; set; }
    /// <summary>
    /// Фамилия
    /// </summary>
    [Required(ErrorMessage = "Last Name is required to register")]
    [StringLength(40, ErrorMessage = "Last Name is too long")]
    [Display(Name = "Last Name")]
    public string LastName { get; set; }
    /// <summary>
    /// Полное имя
    /// </summary>
    public string FullName
    {
      get { return LastName + " " + FirstName; }
    }
  }
}
