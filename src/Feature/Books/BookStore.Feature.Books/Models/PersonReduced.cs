using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Feature.Books.Models
{
  public class PersonReduced
  {
    public Guid Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string FullName
    {
      get { return LastName + " " + FirstName; }
    }
  }
}
