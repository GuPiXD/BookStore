using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using AutoMapper;
using BookStore.Feature.Authors.Models;
using BookStore.Data.DataDB.BL.DTOs;
using BookStore.Data.DataDB.BL;

namespace BookStore.Feature.Authors.Controllers
{
  public class AuthorsController : Controller
  {
    private IMapper mapper;
    private BookStore.Data.DataDB.BL.IUnitOfWork unitOfWork;
    public AuthorsController(IUnitOfWork unitOfWork, IMapper mapper)
    {
      this.mapper = mapper;
      this.unitOfWork = unitOfWork;
    }

    [HttpGet]
    public ActionResult Index()
    {
      var authors = unitOfWork.authors().GetAll().Select(a => mapper.Map<AuthorDTO, IndexViewModel>(a));
      return View(authors);
    }

    [HttpGet]
    public ActionResult Details(string Id)
    {
      var authorDTO = unitOfWork.authors().Get(Id);
      if (authorDTO == null)
      {
        return NotFound("The author Id does not match any existing entries");
      }

      return View(mapper.Map<AuthorDTO, DetailsViewModel>(authorDTO));
    }

    public ActionResult New()
    {
      return View("AuthorForm", new FormViewModel { Id = "0" });
    }

    [HttpGet]
    public ActionResult Edit(string Id)
    {
      var authorDTO = unitOfWork.authors().Get(Id);

      if (authorDTO == null)
      {
        return NotFound("The author Id does not match any existing entries");
      }

      return View("AuthorForm", mapper.Map<AuthorDTO, FormViewModel>(authorDTO));
    }

    [HttpPost]
    public ActionResult Save(FormViewModel author)
    {
      if (!ModelState.IsValid)
      {
        return View("AuthorForm", author);
      }

      if (author.Id == "0")
      {
        unitOfWork.authors().Create(mapper.Map<FormViewModel, AuthorDTO>(author));
      }
      else
      {
        var authorDTO = unitOfWork.authors().Get(author.Id);
        if (authorDTO == null)
          return NotFound("The author Id does not match any existing entries");

        unitOfWork.authors().Update(mapper.Map<FormViewModel, AuthorDTO>(author));
      }

      unitOfWork.Save();

      return RedirectToAction("Index", "Authors");
    }

    [HttpPost]
    public ActionResult Delete(string Id)
    {
      var authorDTO = unitOfWork.authors().Get(Id);
      if (authorDTO == null)
      {
        return NotFound("The author Id does not match any existing entries");
      }

      unitOfWork.authors().Delete(Id);
      unitOfWork.Save();

      return RedirectToAction("Index", "Authors");
    }
  }
}
