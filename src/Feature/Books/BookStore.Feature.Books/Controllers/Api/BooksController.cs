using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;
using AutoMapper;
using BookStore.Feature.Books.Models;
using BookStore.Data.DataDB.BL.DTOs;
using BookStore.Data.DataDB.BL;


namespace BookStore.Feature.Books.Controllers.Api
{
  [Route("/api/[controller]")]
  [ApiController]
  public class BooksController : Controller
  {
    private IMapper mapper;
    private IUnitOfWork unitOfWork;

    public BooksController(IUnitOfWork unitOfWork, IMapper mapper)
    {
      this.mapper = mapper;
      this.unitOfWork = unitOfWork;
    }

    // GET api/values
    [HttpGet]
    public JsonResult  GetAmount()
    {
      var bookAmount = unitOfWork.books().GetAmount();
      return Json(bookAmount);
    }

    [HttpGet]
    public JsonResult GetMore(int skip)
    {
      var books = unitOfWork.books().GetAll(skip).Select(b => mapper.Map<BookDTO, IndexViewModel>(b));
      return Json(books);
    }

    // GET: api/<BooksController>
    [HttpGet]
    public IEnumerable<string> Get()
    {
      return new string[] { "value1", "value2" };
    }

    // GET api/<BooksController>/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
      return "value";
    }

    // POST api/<BooksController>
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    // PUT api/<BooksController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<BooksController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
  }
}
