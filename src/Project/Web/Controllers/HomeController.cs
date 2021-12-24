using BookStore.Web.BookStore.Models;
using BookStore.Web.BookStore.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
  public class HomeController : Controller
  {

    // создаем контекст данных
    private BookContext db;
    public HomeController(BookContext bookContext)
    {
      db = bookContext;
    }

    public IActionResult Index()
    {
      // возвращаем представление
      var books = db.Books.Include(b => b.Authors  ).Include(s => s.PublishingHouse);

      return View(books.ToList());
    }
  }
}
