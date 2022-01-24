using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Data.DataDB.BL.DTOs
{
  public class PublishingHouseDTO
  {
    public string Id { get; set; }
    public string Name { get; set; }
    public ICollection<BookDTO> Books { get; set; }
    public PublishingHouseDTO()
    {
      Books = new List<BookDTO>();
    }
  }
}
