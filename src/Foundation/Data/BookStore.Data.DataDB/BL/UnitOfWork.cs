using System;
using AutoMapper;
using BookStore.Data.DataDB.DAL;

namespace BookStore.Data.DataDB.BL
{
  class UnitOfWork : IUnitOfWork
  {
    private BookLibraryDbContext context;
    private IMapper mapper;

    private AuthorRepository authorRepository;
    private ClientRepository clientRepository;
    private BookRepository bookRepository;
    private CheckoutHistoryRepository checkoutHistoryRepository;
    private PublishingHouseRepository publishingHouseRepository;

    public UnitOfWork(BookLibraryDbContext context, IMapper mapper)
    {
      this.context = context;
      this.mapper = mapper;
    }

    public AuthorRepository authors()
    {
      if (authorRepository == null)      
        authorRepository = new AuthorRepository(context, mapper);
      
      return authorRepository;
    }

    public ClientRepository clients()
    {
      if (clientRepository == null)      
        clientRepository = new ClientRepository(context, mapper);
      
      return clientRepository;
    }

    public BookRepository books()
    {
      if (bookRepository == null)      
        bookRepository = new BookRepository(context, mapper);
      
      return bookRepository;
    }

    public CheckoutHistoryRepository checkoutHistories()
    {
      if (checkoutHistoryRepository == null)      
        checkoutHistoryRepository = new CheckoutHistoryRepository(context, mapper);
      
      return checkoutHistoryRepository;
    }

    public PublishingHouseRepository publishingHouse()
    {
      if (publishingHouseRepository == null)      
        publishingHouseRepository = new PublishingHouseRepository(context, mapper);
      
      return publishingHouseRepository;
    }

    //Saving db context
    public void Save()
    {
      context.SaveChanges();
    }

    //Disposing of the db context
    private bool disposed = false;

    public virtual void Dispose(bool disposing)
    {
      if (!this.disposed)
      {
        if (disposing)
        {
          context.Dispose();
        }
        this.disposed = true;
      }
    }

    public void Dispose()
    {
      Dispose(true);
      GC.SuppressFinalize(this);
    }
  }
}
