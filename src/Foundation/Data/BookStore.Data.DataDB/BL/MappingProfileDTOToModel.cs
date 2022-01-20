
using AutoMapper;
using BookStore.Data.DataDB.DAL.Models;
using BookStore.Data.DataDB.BL.DTOs;

namespace BookStore.Data.DataDB.BL
{
  public class MappingProfileDTOToModel : Profile
  {
    public MappingProfileDTOToModel()
    {
      CreateMap<Author, AuthorDTO>();
      CreateMap<AuthorDTO, Author>();

      CreateMap<Book, BookDTO>();
      CreateMap<BookDTO, Book>();

      CreateMap<Client, ClientDTO>();
      CreateMap<ClientDTO, Client>();

      CreateMap<CheckoutHistory, CheckoutHistoryDTO>();
      CreateMap<CheckoutHistoryDTO, CheckoutHistory>();

      CreateMap<PublishingHouse, PublishingHouseDTO>();
      CreateMap<PublishingHouseDTO, PublishingHouse>();
    }
  }
}
