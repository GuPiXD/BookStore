using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using BookStore.Data.DataDB.DAL.Models;
using BookStore.Data.DataDB.DAL;
using BookStore.Data.DataDB.BL.DTOs;

namespace BookStore.Data.DataDB.BL
{
  public class CheckoutHistoryRepository : IRepository<CheckoutHistoryDTO>
  {
    private IMapper mapper;

    private BookLibraryDbContext context;
    public CheckoutHistoryRepository(BookLibraryDbContext context, IMapper mapper)
    {
      this.context = context;
      this.mapper = mapper;
    }

    public void Create(CheckoutHistoryDTO historyDTO)
    {
      //Detaching Author entity with same Id as Client just in case an Author and a Client exist with the same Id in the People Table
      var authorInDB = context.Authors.SingleOrDefault(a => a.Id.ToString() == historyDTO.Client.Id);
      if (authorInDB != null)      
        context.Entry(authorInDB).State = EntityState.Detached;      

      var checkoutHistory = new CheckoutHistory
      {
        Book         = context.Books.SingleOrDefault(b => b.ISBN == historyDTO.Book.ISBN),
        Client       = context.Clients.SingleOrDefault(c => c.Id.ToString() == historyDTO.Client.Id),
        CheckoutDate = historyDTO.CheckoutDate,
        ReturnDate   = historyDTO.ReturnDate
      };
      context.CheckoutHistories.Add(checkoutHistory);
    }

    public void Delete(string id)
    {
      throw new NotImplementedException();
    }

    public CheckoutHistoryDTO Get(string id)
    {
      throw new NotImplementedException();
    }

    public IEnumerable<CheckoutHistoryDTO> GetAll()
    {
      var checkoutHistoryQuery = context.CheckoutHistories.Include(c => c.Client).Include(c => c.Book).ToList();
      var checkoutHistoryDTOList = checkoutHistoryQuery.Select(c => {
        var b = mapper.Map<CheckoutHistory, CheckoutHistoryDTO>(c);
        b.Client.Id = c.Client.Id.ToString();
        b.Id = c.Id.ToString();
        return (b);
      });

      return checkoutHistoryDTOList;
    }

    public int GetAmount()
    {
      throw new NotImplementedException();
    }

    public void Update(CheckoutHistoryDTO item)
    {
      throw new NotImplementedException();
    }
  }
}
