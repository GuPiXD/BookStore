using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Data.DataDB.DAL.Models
{
  public class Book
  {
    /// <summary>
    /// Международный стандартный книжный номер (International Standard Book Number)
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    [RegularExpression(@"^[1-9]+[0-9-]{0,20}$")]
    public string ISBN { get; set; }
    /// <summary>
    /// Авторов книги
    /// </summary>
    [Required]
    public ICollection<Author> Authors { get; set; }
    /// <summary>
    /// Название книги
    /// </summary>
    [Required]
    public string Name { get; set; }
    /// <summary>
    /// Количество страниц
    /// </summary>
    [Range(1, 5000)]
    public short NumberPages { get; set; }
    /// <summary>
    /// Количество книг в наличии
    /// </summary>
    [Range(0, 500)]
    public short NumberStock { get; set; }
    /// <summary>
    /// Издательство
    /// </summary>
    [Required]
    public PublishingHouse PublishingHouse { get; set; }
    /// <summary>
    /// Цена
    /// </summary>
    public double Price { get; set; }
  }
}
