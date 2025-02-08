using AutoMapper;

namespace spinalproject.src.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserEntity, userDTO>();
            CreateMap<userDTO, UserEntity>();

        }
    }
}
