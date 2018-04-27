using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.AutoMapper
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<DomainToViewModelMappingProfile>();
                x.AddProfile<ViewModelToDomainMappingProfile>();
                x.ForAllMaps((tm, me) => me.ForAllMembers(option => option.Condition((source, destination, sourceMember) => sourceMember != null)));
            });
        }
    }
}
