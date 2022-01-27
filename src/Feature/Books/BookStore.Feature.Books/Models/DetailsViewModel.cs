using System.Collections.Generic;

namespace BookStore.Feature.Books.Models
{
  public class DetailsViewModel
  {
    public string ISBN { get; set; }

    public string Name { get; set; }

    public short NumberStock { get; set; }

    public short NumberPages { get; set; }

    public PublishingHouseReduced PublishingHouse { get; set; }

    public IEnumerable<PersonReduced> Authors { get; set; }

    public DetailsViewModel()
    {
      Authors = new List<PersonReduced>();
    }
  }
}
