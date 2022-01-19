
namespace BookStore.Data.DataDB.BL
{
  interface IUnitOfWork
  {
    AuthorRepository authors();

    ClientRepository clients();

    BookRepository books();

    CheckoutHistoryRepository checkoutHistories();

    PublishingHouseRepository publishingHouse();

    void Save();
  }
}
