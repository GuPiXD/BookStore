using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Data.DataDB.BL.DTOs
{
  public class CheckoutHistoryDTO
  {
    public string Id { get; set; }
    public ClientDTO Client { get; set; }
    public BookDTO Book { get; set; }
    public DateTime CheckoutDate { get; set; }
    public DateTime? ReturnDate { get; set; }
  }
}
