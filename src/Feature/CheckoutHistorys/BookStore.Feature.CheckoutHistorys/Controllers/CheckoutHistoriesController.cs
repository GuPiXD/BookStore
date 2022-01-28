using BookStore.Feature.CheckoutHistorys.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using AutoMapper;
using BookStore.Data.DataDB.BL.DTOs;
using BookStore.Data.DataDB.BL;

namespace BookStore.Feature.CheckoutHistorys.Controllers
{
  public class CheckoutHistoriesController : Controller
  {
    private IMapper mapper;
    private IUnitOfWork unitOfWork;

    public CheckoutHistoriesController(IUnitOfWork unitOfWork, IMapper mapper)
    {
      this.mapper = mapper;
      this.unitOfWork = unitOfWork;
    }

    [HttpGet]
    public IActionResult Index()
    {
      var checkoutHistories = unitOfWork.checkoutHistories().GetAll().Select(c => mapper.Map<CheckoutHistoryDTO, IndexViewModel>(c));
      return View(checkoutHistories);
    }
  }
}
