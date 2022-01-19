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
  public class PublishingHouseRepository : IRepository<PublishingHouseDTO>
  {
    private IMapper mapper;

    private BookLibraryDbContext context;
    public PublishingHouseRepository(BookLibraryDbContext context, IMapper mapper)
    {
      this.context = context;
      this.mapper = mapper;
    }

    public void Create(PublishingHouseDTO publishingHouseDTO)
    {
      context.PublishingHouses.Add(mapper.Map<PublishingHouseDTO, PublishingHouse>(publishingHouseDTO));
    }

    public void Delete(string id)
    {
      var publishingHouseInDB = context.PublishingHouses.SingleOrDefault(a => a.Id.ToString() == id);
      if (publishingHouseInDB != null)      
        context.PublishingHouses.Remove(publishingHouseInDB);      
    }

    public PublishingHouseDTO Get(string id)
    {
      var publishingHouseInDB = context.PublishingHouses.Include(a => a.Books).AsNoTracking().SingleOrDefault(a => a.Id.ToString() == id);
      var publishingHouseDTO = mapper.Map<PublishingHouse, PublishingHouseDTO>(publishingHouseInDB);
      publishingHouseDTO.Id = publishingHouseInDB.Id.ToString();

      return publishingHouseDTO;
    }

    public IEnumerable<PublishingHouseDTO> GetAll()
    {
      var publishingHouseQuery = context.PublishingHouses.Include(a => a.Books).ToList();

      var publishingHouseDetailedDTOList = publishingHouseQuery.Select(a => {
        var b = mapper.Map<PublishingHouse, PublishingHouseDTO>(a);
        b.Id = a.Id.ToString();
        return (b);
      });

      return publishingHouseDetailedDTOList;
    }

    public int GetAmount()
    {
      throw new NotImplementedException();
    }

    public void Update(PublishingHouseDTO publishingHouseDTO)
    {
      var publishingHouse = mapper.Map<PublishingHouseDTO, PublishingHouse>(publishingHouseDTO);
      publishingHouse.Id = new Guid(publishingHouseDTO.Id);

      context.Entry(publishingHouse).State = EntityState.Modified;
    }
  }
}
