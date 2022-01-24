using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using BookStore.Data.DataDB.DAL.Models;
using BookStore.Data.DataDB.DAL;
using BookStore.Data.DataDB.BL.DTOs;

namespace BookStore.Data.DataDB.BL
{
  public class BookRepository : IRepository<BookDTO>
  {
    private IMapper mapper;
    private int booksShown = 3;

    private BookLibraryDbContext context;
    public BookRepository(BookLibraryDbContext context, IMapper mapper)
    {
      this.context = context;
      this.mapper = mapper;
    }

    public void Create(BookDTO bookDTO)
    {
      var book = mapper.Map<BookDTO, Book>(bookDTO);
      book.Authors = new List<Author>();
      foreach (var author in bookDTO.Authors)
      {
        var authorInDB = context.Authors.SingleOrDefault(a => a.Id.ToString() == author.Id);
        book.Authors.Add(authorInDB);
      }

      context.Books.Add(book);
    }

    public void Delete(string id)
    {
      var bookInDB = context.Books.SingleOrDefault(b => b.ISBN == id);
      if (bookInDB != null)
      {
        context.Books.Remove(bookInDB);
      }
    }

    public BookDTO Get(string id)
    {
      var bookInDB = context.Books.Include(a => a.Authors).AsNoTracking().SingleOrDefault(b => b.ISBN == id);
      var bookDTO = mapper.Map<Book, BookDTO>(bookInDB);
      return bookDTO;
    }

    public IEnumerable<BookDTO> GetAll()
    {
      var bookQuery = context.Books.Include(b => b.Authors).OrderBy(b => b.ISBN).Take(booksShown).ToList();
      var bookDTOList = bookQuery
          //Maps each element of query from Book to a BookDTO
          .Select(b => mapper.Map<Book, BookDTO>(b))
          //For each element checks if a matching Book is involved in a CheckoutHistory and has a null ReturnDate. If such entries exist, then the current elements' IsCheckedout is set to True
          .Select(b =>
          {
            var history = context.CheckoutHistories.Include(c => c.Book).Where(c => c.Book.ISBN == b.ISBN).Select(c => c).Where(c => c.ReturnDate == null);
            if (history.Count() > 0)
              b.IsCheckedout = true;
            return b;
          });

      return bookDTOList;
    }

    public IEnumerable<BookDTO> GetAll(int skip)
    {
      var bookQuery = context.Books.Include(b => b.Authors).OrderBy(b => b.ISBN).Skip(skip * booksShown).Take(booksShown).ToList();
      var bookDTOList = bookQuery
          //Maps each element of query from Book to a BookDTO
          .Select(b => mapper.Map<Book, BookDTO>(b))
          //For each element checks if a matching Book is involved in a CheckoutHistory and has a null ReturnDate. If such entries exist, then the current elements' IsCheckedout is set to True
          .Select(b =>
          {
            var history = context.CheckoutHistories.Include(c => c.Book).Where(c => c.Book.ISBN == b.ISBN).Select(c => c).Where(c => c.ReturnDate == null);
            if (history.Count() > 0)
              b.IsCheckedout = true;
            return b;
          });

      return bookDTOList;
    }

    public int GetAmount()
    {
      var bookAmount = context.Books.Count();
      return bookAmount;
    }

    public void Update(BookDTO bookDTO)
    {
      var book = context.Books.Include(b => b.Authors).SingleOrDefault(b => b.ISBN == bookDTO.ISBN);
      book.NumberStock = bookDTO.NumberStock;
      book.NumberPages = bookDTO.NumberPages;
      book.Name        = bookDTO.Name;
      book.Authors     = new List<Author>();
      foreach (var author in bookDTO.Authors)
      {
        var authorInDB = context.Authors.SingleOrDefault(a => a.Id.ToString() == author.Id);
        book.Authors.Add(authorInDB);
      }

      context.Entry(book).State = EntityState.Modified;
    }
  }
}
