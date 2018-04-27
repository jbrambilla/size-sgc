using AutoMapper;
using Domain.Entity;
using Domain.ViewModels;

namespace Service.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<User, UserViewModel>();
            CreateMap<Demand, DemandViewModel>();
            CreateMap<Category, CategoryViewModel>();
        }
    }
}
