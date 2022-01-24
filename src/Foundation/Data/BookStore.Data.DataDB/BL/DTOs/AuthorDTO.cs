using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Data.DataDB.BL.DTOs
{
  public class AuthorDTO
  {
    //AuthorDTO
    public string Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public byte? Rating { get; set; }

    public ICollection<BookDTO> Books { get; set; }

    public AuthorDTO()
    {
      Books = new List<BookDTO>();
    }
  }
}
