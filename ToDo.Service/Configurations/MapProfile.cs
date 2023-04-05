using AutoMapper;
using ToDo.Domain.Dtos.User;
using ToDo.Domain.Entities;

namespace ToDo.Service.Configurations
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<UserEntity, UserInsertDto>()
                    .ReverseMap();
        }
    }
}