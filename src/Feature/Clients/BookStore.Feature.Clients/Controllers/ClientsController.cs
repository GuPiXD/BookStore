using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using BookStore.Data.DataDB.BL.DTOs;
using BookStore.Data.DataDB.BL;
using BookStore.Feature.Clients.Models;
using System.Linq;

namespace BookStore.Feature.Clients.Controllers
{
  public class ClientsController : Controller
  {
    private IMapper mapper;
    private IUnitOfWork unitOfWork;
    public ClientsController(IUnitOfWork unitOfWork, IMapper mapper)
    {
      this.mapper = mapper;
      this.unitOfWork = unitOfWork;
    }

    [HttpGet]
    public ActionResult Index()
    {
      var clients = unitOfWork.clients().GetAll().Select(c => mapper.Map<ClientDTO, IndexViewModel>(c));
      return View(clients);
    }

    [HttpGet]
    public ActionResult Details(string Id)
    {
      var clientDTO = unitOfWork.clients().Get(Id);
      if (clientDTO == null)
      {
        return NotFound("The client Id does not match any existing entries");
      }

      return View(mapper.Map<ClientDTO, DetailsViewModel>(clientDTO));
    }

    public ActionResult New()
    {
      return View("ClientForm", new FormViewModel { Id = "0" });
    }

    [HttpGet]
    public ActionResult Edit(string Id)
    {
      var clientDTO = unitOfWork.clients().Get(Id);

      if (clientDTO == null)
      {
        return NotFound("The client Id does not match any existing entries");
      }

      return View("ClientForm", mapper.Map<ClientDTO, FormViewModel>(clientDTO));
    }

    [HttpPost]
    public ActionResult Save(FormViewModel client)
    {
      if (!ModelState.IsValid)
      {
        return View("ClientForm", client);
      }

      if (client.Id == "0")
      {
        unitOfWork.clients().Create(mapper.Map<FormViewModel, ClientDTO>(client));
      }
      else
      {
        var clientDTO = unitOfWork.clients().Get(client.Id);
        if (clientDTO == null)
        {
          return NotFound("The client Id does not match any existing entries");
        }

        unitOfWork.clients().Update(mapper.Map<FormViewModel, ClientDTO>(client));
      }

      unitOfWork.Save();

      return RedirectToAction("Index");
    }

    [HttpPost]
    public ActionResult Delete(string Id)
    {
      var clientDTO = unitOfWork.clients().Get(Id);
      if (clientDTO == null)
      {
        return NotFound("The client Id does not match any existing entries");
      }

      unitOfWork.clients().Delete(Id);
      unitOfWork.Save();

      return RedirectToAction("Index", "Clients");
    }
  }
}
