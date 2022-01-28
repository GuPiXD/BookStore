using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BookStore.Data.DataDB.BL.DTOs;
using BookStore.Data.DataDB.BL;
using BookStore.Feature.Books.Models;
using System.Drawing;
using System.IO;
using System.Web;

namespace BookStore.Feature.Books.Controllers
{
  public class BooksController : Controller
  {
    private IMapper mapper;
    private IUnitOfWork unitOfWork;
    public BooksController(IUnitOfWork unitOfWork, IMapper mapper)
    {
      this.mapper = mapper;
      this.unitOfWork = unitOfWork;
    }

    [HttpGet]
    public ActionResult Index()
    {
      return View();
    }

    [HttpGet]
    public ActionResult Checkout(string ISBN)
    {
      var bookDTO = unitOfWork.books().Get(ISBN);
      if (bookDTO == null)      
        return NotFound("The book ISBN does not match any existing entries");      

      var clientDTOList = unitOfWork.clients().GetAll();
      if (clientDTOList.Count() == 0)      
        return NotFound("There are no clients available to check-out a book");      

      var viewModel = new CheckoutFormViewModel();
      viewModel         = mapper.Map<BookDTO, CheckoutFormViewModel>(bookDTO);
      viewModel.Clients = clientDTOList.Select(c => mapper.Map<ClientDTO, PersonReduced>(c));

      return View(viewModel);
    }

    [HttpPost]
    public ActionResult Checkout(CheckoutFormViewModel model)
    {

      if (!ModelState.IsValid)
      {
        model.Clients = unitOfWork.clients().GetAll().Select(c => mapper.Map<ClientDTO, PersonReduced>(c));
        model.Authors = unitOfWork.books().Get(model.ISBN).Authors.Select(a => mapper.Map<AuthorDTO, PersonReduced>(a));

        return View("Checkout", model);
      }

      var bookDTO = unitOfWork.books().Get(model.ISBN);
      if (bookDTO == null)      
        return NotFound("The book ISBN does not match any existing entries");      

      var clientDTO = unitOfWork.clients().Get(model.ClientId);
      if (clientDTO == null)      
        return NotFound("The cleint Id does not match any existing entries");      

      bookDTO.NumberStock--;
      model.CheckoutDate = DateTime.Now;
      var checkoutHistoryDTO = new CheckoutHistoryDTO
      {
        Book = bookDTO,
        Client = clientDTO,
        CheckoutDate = model.CheckoutDate
      };

      unitOfWork.books().Update(bookDTO);
      unitOfWork.checkoutHistories().Create(checkoutHistoryDTO);

      unitOfWork.Save();

      return RedirectToAction("Index", "Books");
    }

    [HttpGet]
    public ActionResult Details(string ISBN)
    {
      var bookDTO = unitOfWork.books().Get(ISBN);
      if (bookDTO == null)      
        return NotFound("The book ISBN does not match any existing entries");      

      var viewModel = mapper.Map<BookDTO, DetailsViewModel>(bookDTO);

      return View(viewModel);
    }

    [HttpPost]
    public ActionResult Details(DetailsViewModel viewModel)
    {
      viewModel.Authors = new List<PersonReduced>();
      viewModel.Authors = unitOfWork.books().Get(viewModel.ISBN).Authors.Select(a => mapper.Map<AuthorDTO, PersonReduced>(a));
      if (!ModelState.IsValid)      
        return View("Details", viewModel);      

      return View(viewModel);
    }

    [HttpGet]
    public ActionResult Edit(string ISBN)
    {
        var bookDTO = unitOfWork.books().Get(ISBN);
        if (bookDTO == null)        
            return NotFound("The book ISBN does not match any existing entries");
        
        var viewModel = mapper.Map<BookDTO, BookFormViewModel>(bookDTO);
        if (viewModel.Authors.Count() > 0)
        {
            viewModel.AuthorId = new List<Guid>();
            foreach (var author in viewModel.Authors)            
                viewModel.AuthorId.Add(author.Id);            
        }

        ViewBag.AuthorsList = unitOfWork.authors().GetAll().Select(a => mapper.Map<AuthorDTO, PersonReduced>(a));
        ViewBag.DoesExist = true;
        return View("BookForm", viewModel);
    }

    [HttpGet]
    public ActionResult New()
    {
      ViewBag.AuthorsList = unitOfWork.authors().GetAll().Select(a => mapper.Map<AuthorDTO, PersonReduced>(a));
      ViewBag.DoesExist = false;

      TempData = null;

      return View("BookForm", new BookFormViewModel());
    }

    [HttpPost]
    public ActionResult Save(BookFormViewModel book)
    {
      if (!ModelState.IsValid)
      {
        if (unitOfWork.books().Get(book.ISBN) != null)
        {
          book.Authors = unitOfWork.books().Get(book.ISBN).Authors.Select(a => mapper.Map<AuthorDTO, PersonReduced>(a));
          ViewBag.DoesExist = true;
        }
        else
        {
          ViewBag.DoesExist = false;
        }
        ViewBag.AuthorsList = unitOfWork.authors().GetAll().Select(a => mapper.Map<AuthorDTO, PersonReduced>(a));
        //Don't know how to insert picture data into form
        return View("BookForm", book);
      }

      var bookDTO = mapper.Map<BookFormViewModel, BookDTO>(book);
      bookDTO.Authors = new List<AuthorDTO>();
      foreach (var author in book.AuthorId)      
        bookDTO.Authors.Add(unitOfWork.authors().Get(author.ToString()));      

      if (unitOfWork.books().Get(book.ISBN) != null)      
        unitOfWork.books().Update(bookDTO);      
      else      
        unitOfWork.books().Create(bookDTO);      

      unitOfWork.Save();

      return RedirectToAction("Index", "Books");
    }

    [HttpPost]
    public ActionResult Delete(string ISBN)
    {
      var bookDTO = unitOfWork.books().Get(ISBN);
      if (bookDTO == null)      
        return NotFound("The book ISBN does not match any existing entries");      

      unitOfWork.books().Delete(ISBN);
      unitOfWork.Save();

      return RedirectToAction("Index", "Books");
    }

    protected virtual void Dispose(bool disposing)
    {
      unitOfWork.Dispose();
      Dispose();
    }
  }
}
