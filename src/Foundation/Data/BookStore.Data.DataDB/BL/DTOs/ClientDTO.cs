using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Data.DataDB.BL.DTOs
{
  public class ClientDTO
  {
    public string Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Address { get; set; }

    public string Email { get; set; }

    public string Phone { get; set; }

    public string Job { get; set; }
  }
}
