using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Feature.Clients.Models
{
  public class IndexViewModel
  {
    public string Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Job { get; set; }

    public string FullName
    {
      get { return LastName + " " + FirstName; }
    }
  }
}
