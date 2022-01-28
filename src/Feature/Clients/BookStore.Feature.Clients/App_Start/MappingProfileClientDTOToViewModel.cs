using AutoMapper;
using BookStore.Data.DataDB.BL.DTOs;
using BookStore.Feature.Clients.Models;

namespace BookStore.Feature.Clients.App_Start
{
  public class MappingProfileClientDTOToViewModel : Profile
  {
    public MappingProfileClientDTOToViewModel()
    {
      CreateMap<ClientDTO, DetailsViewModel>();
      CreateMap<ClientDTO, FormViewModel>();
      CreateMap<ClientDTO, IndexViewModel>();
      CreateMap<FormViewModel, ClientDTO>();
    }
  }
}
