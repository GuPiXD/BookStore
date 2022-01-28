using AutoMapper;
using BookStore.Feature.Authors.Models;
using BookStore.Data.DataDB.BL.DTOs;

namespace BookStore.Feature.Authors.App_Start
{
  public class MappingProfileAuthorDTOToViewModel : Profile
  {
    public MappingProfileAuthorDTOToViewModel()
    {
      CreateMap<AuthorDTO, DetailsViewModel>();
      CreateMap<AuthorDTO, FormViewModel>();
      CreateMap<AuthorDTO, IndexViewModel>();
      CreateMap<FormViewModel, AuthorDTO>();
      CreateMap<BookDTO, BookReduced>();
    }
  }
}
