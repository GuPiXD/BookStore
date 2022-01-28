using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Feature.Clients.Models
{
  public class DetailsViewModel
  {
    public string Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string FullName
    {
      get { return LastName + " " + FirstName; }
    }

    public string Address { get; set; }

    public string Email { get; set; }

    public string Phone { get; set; }

    public string Job { get; set; }
  }
}
