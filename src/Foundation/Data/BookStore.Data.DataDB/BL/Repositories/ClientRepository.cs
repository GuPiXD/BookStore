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
  public class ClientRepository : IRepository<ClientDTO>
  {
    private IMapper mapper;

    private BookLibraryDbContext context;
    public ClientRepository(BookLibraryDbContext context, IMapper mapper)
    {
      this.context = context;
      this.mapper = mapper;
    }

    public void Create(ClientDTO clientDTO)
    {
      context.Clients.Add(mapper.Map<ClientDTO, Client>(clientDTO));
    }

    public void Delete(string id)
    {
      var clientInDB = context.Clients.SingleOrDefault(c => c.Id.ToString() == id);
      if (clientInDB != null)
      {
        context.Clients.Remove(clientInDB);
      }
    }

    public ClientDTO Get(string id)
    {
      //Added AsNoTracking() because this method is used to check null references in the Edit action in the ClientsController. The entity won't be updatable otherwise
      var clientInDB = context.Clients.AsNoTracking().SingleOrDefault(c => c.Id.ToString() == id);
      var clientDTO = mapper.Map<Client, ClientDTO>(clientInDB);
      clientDTO.Id = clientInDB.Id.ToString();

      return clientDTO;
    }

    public IEnumerable<ClientDTO> GetAll()
    {
      var clientQuery = context.Clients.ToList();
      var clientDTOList = clientQuery.Select(c => {
        var b = mapper.Map<Client, ClientDTO>(c);
        b.Id = c.Id.ToString();
        return (b);
      });

      return clientDTOList;
    }

    public int GetAmount()
    {
      throw new NotImplementedException();
    }

    public void Update(ClientDTO clientDTO)
    {
      var client = mapper.Map<ClientDTO, Client>(clientDTO);
      client.Id  = new Guid(clientDTO.Id);

      context.Entry(client).State = EntityState.Modified;
    }
  }
}
