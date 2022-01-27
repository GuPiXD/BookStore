using System;

namespace BookStore.Data.DataDB.BL
{
  public interface IUnitOfWork : IDisposable
  {
    AuthorRepository authors();

    ClientRepository clients();

    BookRepository books();

    CheckoutHistoryRepository checkoutHistories();

    PublishingHouseRepository publishingHouse();

    void Save();
  }
}
