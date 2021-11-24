using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Web.BookStore.Models
{
  public class Book
  {
    /// <summary>
    /// ID книги
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// Автор/Авторы книги
    /// </summary>
    public Guid[] AuthorsId { get; set; }
    /// <summary>
    /// Тип переплета
    /// </summary>
    public enBindingType BindingType { get; set; }
    /// <summary>
    /// Количество страниц
    /// </summary>
    public int NumberPages { get; set; }
    /// <summary>
    /// Количество книг в наличии
    /// </summary>
    public int NumberBooksStock { get; set; }
    /// <summary>
    /// Международный стандартный книжный номер (International Standard Book Number)
    /// </summary>
    public string ISBN { get; set; }
    /// <summary>
    /// Название книги
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// Серия
    /// </summary>
    public string Series { get; set; }
    /// <summary>
    /// Издательство
    /// </summary>
    public PublishingHouse PublishingHouse { get; set; }
    /// <summary>
    /// Год издания
    /// </summary>
    public DateTime YearPublishing {get;set;}
    /// <summary>
    /// Цена
    /// </summary>
    public double Price { get; set; }
  }
}
