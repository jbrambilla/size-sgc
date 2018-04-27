using AutoMapper;
using Domain.Entity;
using Domain.ViewModels;

namespace Service.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<UserViewModel, User>()
                .ForMember(d => d.Id, opt => opt.Ignore());

            CreateMap<DemandViewModel, Demand>()
                .ForMember(d => d.Id, opt => opt.Ignore());

            CreateMap<CategoryViewModel, Category>()
                .ForMember(d => d.Id, opt => opt.Ignore());
        }
    }
}
