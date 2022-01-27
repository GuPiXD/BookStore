using AutoMapper;
using BookStore.Data.DataDB.BL.DTOs;
using BookStore.Feature.Books.Models;

namespace BookStore.Feature.Books.App_Start
{
  public class MappingProfileBookDTOToViewModel : Profile
  {
    public MappingProfileBookDTOToViewModel()
    {
      CreateMap<BookDTO, IndexViewModel>();
      CreateMap<AuthorDTO, PersonReduced>();
      CreateMap<ClientDTO, PersonReduced>();
      CreateMap<BookDTO, CheckoutFormViewModel>();
      CreateMap<BookDTO, BookFormViewModel>();
      CreateMap<BookFormViewModel, BookDTO>();
      CreateMap<BookDTO, DetailsViewModel>();
    }
  }
}
