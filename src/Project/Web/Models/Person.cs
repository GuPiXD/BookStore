using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Web.BookStore.Models
{
  /// <summary>
  /// Человек
  /// </summary>
  interface IPerson
  {
    /// <summary>
    /// Фамилия
    /// </summary>
    string LastName { get; set; }
    /// <summary>
    /// Имя
    /// </summary>
    string FirstName { get; set; }
    /// <summary>
    /// Отчество
    /// </summary>
    string MiddleName { get; set; }
    /// <summary>
    /// Дата рождения
    /// </summary>
    DateTime DateBirth { get; set; }
  }
}
