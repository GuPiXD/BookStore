using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Data.DataDB.BL.DTOs
{
  public class BookDTO
  {
    public string ISBN { get; set; }
    public string Name { get; set; }
    public short NumberPages { get; set; }
    public short NumberStock { get; set; }
    public ICollection<AuthorDTO> Authors { get; set; }
    public PublishingHouseDTO PublishingHouse { get; set; }
    public BookDTO()
    {
      Authors = new List<AuthorDTO>();
    }
    public bool IsCheckedout { get; set; }
  }
}
