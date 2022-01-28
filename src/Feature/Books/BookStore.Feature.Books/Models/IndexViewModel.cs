using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Feature.Books.Models
{
  public class IndexViewModel
  {
    public string ISBN { get; set; }

    public string Name { get; set; }

    public short NumberStock { get; set; }
    public PublishingHouseReduced PublishingHouse { get; set; }

    public ICollection<PersonReduced> Authors { get; set; }

    public IndexViewModel()
    {
      Authors = new List<PersonReduced>();
    }

    public bool IsCheckedout { get; set; }
  }
}
