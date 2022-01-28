using AutoMapper;
using BookStore.Data.DataDB.BL.DTOs;
using BookStore.Feature.CheckoutHistorys.Models;

namespace BookStore.Feature.CheckoutHistorys.App_Start
{
  public class MappingProfileCheckoutHistoryDTOToViewModel : Profile
  {
    public MappingProfileCheckoutHistoryDTOToViewModel()
    {
      CreateMap<CheckoutHistoryDTO, IndexViewModel>();
      CreateMap<BookDTO, BookReduced>();
      CreateMap<ClientDTO, ClientReduced>();
    }
  }
}
